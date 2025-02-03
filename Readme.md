#!/bin/bash
dotnet clean
dotnet build
dotnet run 
dotnet publish -c Release -r linux-x64 --self-contained=true
dotnet publish -c Release -r win-x64 --self-contained=true
dotnet publish -c Release -r osx-x64 --self-contained=true