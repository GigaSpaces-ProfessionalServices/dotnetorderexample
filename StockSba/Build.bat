@echo off
"%windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe" ..\..\Practices\ExternalDataSource\NHibernate\GigaSpaces.Practices.ExternalDataSource.NHibernate.sln
"%windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe" GigaSpaces.Examples.StockSba.sln
"%windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe" Tools\Tools.sln
