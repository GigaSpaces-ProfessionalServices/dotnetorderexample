@echo off
Title="MySQL - Persistency DB"

rem   Update the DB install path here:
set DBLocation=D:\mysql

"%DBLocation%\bin\mysqld" --standalone --console

