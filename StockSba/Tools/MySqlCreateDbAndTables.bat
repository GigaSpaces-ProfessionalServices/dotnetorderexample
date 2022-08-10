rem   Update the DB install path here:
set DBLocation=D:\MySQL

Title="MySQL Create DB and Tables"

call ..\release\Tools.MySqlDb.CreateDbAndTables.exe "%DBLocation%"
