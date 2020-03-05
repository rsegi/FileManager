FROM microsoft/dotnet-framework:4.7.2-sdk AS Build

COPY ./install.ps1 c:/
CMD Set-ExecutionPolicy Bypass

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]
WORKDIR C:/
RUN ./install.ps1

RUN git clone https://github.com/rsegt/FileManager.git

WORKDIR C:/FileManager/
RUN nuget restore ./FileManager.sln

RUN ./Build.ps1

#COPY ./AppSettingsFiles/RepositoryConfiguration.xml .

ENTRYPOINT C:\FileManager\FileManager.Presentation.WinSite\debug\FileManager.Presentation.WinSite.exe
# ENTRYPOINT powershell -command c:\OnInit.ps1

# CMD ping www.github.com