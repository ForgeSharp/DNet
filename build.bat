@echo Building DNET
@echo Remove old directories
rmdir packages /s /q
rmdir paket-files /s /q
@echo Run paket install
paket install
@echo Run dotnet build
dotnet build