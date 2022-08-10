using System;
using GigaSpaces.Practices.ExternalDataSource.NHibernate;
using NHibernate;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace Tools.MySqlDb
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        private const string nhibernateCreateTablesConfigFilePath = "../config/nHibernate/CreateTablesNHibernate.cfg.xml";
        private const string nhibernateHmbFilePath = "../config/nHibernate/";

        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("  MySQL Create DB and Tables Started  ");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();

            if (Process.GetProcessesByName("mysqld").Length > 0)
            {
                Console.WriteLine("** There's a mysql server running on this machine, please stop it rerun the tool");
            }
            else if (args.Length == 1)
            {
                try
                {
                    string mySqlInstallBinDir = args[0];
                    if (!File.Exists(mySqlInstallBinDir + "\\bin\\mysqld.exe"))
                        throw new ArgumentException("Illegal or wrong DB path, please check the DB path specified and try agine.");


                    Process dbProcess = Process.Start(mySqlInstallBinDir + "\\bin\\mysqld.exe", "--standalone --console");
                    Thread.Sleep(2000);

                    Console.WriteLine("* Creating DB");
                    Process createTable = Process.Start(mySqlInstallBinDir + "\\bin\\mysql.exe", "-uroot -e\"CREATE DATABASE stocksba;\"");
                    createTable.WaitForExit();
                    Console.WriteLine("* DB created");
                    Console.WriteLine();

                    Console.WriteLine("* Creating tables");
                    NHibernate.Cfg.Configuration factoryConfig = new NHibernate.Cfg.Configuration();
                    factoryConfig.Configure(nhibernateCreateTablesConfigFilePath);
                    string hbmDir = Path.GetFullPath(nhibernateHmbFilePath);
                    factoryConfig.AddDirectory(new DirectoryInfo(hbmDir));
                    factoryConfig.BuildSessionFactory();

                    Console.WriteLine("* Tables created");

                    dbProcess.Kill();
                }
                catch(Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine("** Exception: " + ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }


            }
            else 
            {
                Console.WriteLine();
                Console.WriteLine("Usage: Tools.MySqlDb.CreateDbAndTables <MySql install dir>");						
            }

            Console.WriteLine();
            Console.WriteLine("Press ENTER to exit");
            Console.ReadLine();
        }
    }
}
