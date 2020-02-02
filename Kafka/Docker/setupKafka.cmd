@echo off
cls

echo Installing and setting up Kafka environment
cd c:\automation\kafka\docker
docker-compose up -d --build

echo.
echo. Starting consumer console window ...
start "CONSUMER" C:\automation\Kafka\kafka.exe consume

echo.
echo. Starting Producer 1: Generating and sending 30 messages to topic cars ...
start "PRODUCER 1" C:\automation\Kafka\kafka.exe produce 30

echo.
echo. Starting Producer 2: Generating and sending 50 messages to topic cars ...
start "PRODUCER 2" C:\automation\Kafka\kafka.exe produce 50

echo.
echo Press any key to kill Docker ...
pause > nul
docker-compose down

echo.
echo Press any key to exit
pause > nul

