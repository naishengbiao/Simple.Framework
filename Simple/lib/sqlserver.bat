@echo.服务启动......
@echo off
@sc start MSSQLSERVER
@sc start SQLSERVERAGENT
@sc start MSSQLServerOLAPService
@sc start msftesql
@sc start MsDtsServer
@sc start SQLWriter
@echo off
@echo.启动完毕！
@pause