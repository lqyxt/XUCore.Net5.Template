#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base

#更换阿里源
ADD ["sources.list", "/etc/apt/"]

#修改时区
RUN rm /etc/localtime 
RUN ln -s /usr/share/zoneinfo/Asia/Shanghai /etc/localtime
CMD rm /etc/localtime && ln -s /usr/share/zoneinfo/Asia/Shanghai /etc/localtime

#添加libgdiplus库
#RUN apt-get update -y && apt-get install -y libgdiplus && apt-get clean && ln -s /usr/lib/libgdiplus.so /usr/lib/gdiplus.dll
#RUN apt-get install -y ghostscript

WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /src
COPY ["XUCore.Net5.Template/XUCore.Net5.Template.WebApi.csproj", "XUCore.Net5.Template/"]
RUN dotnet restore "XUCore.Net5.Template/XUCore.Net5.Template.WebApi.csproj"
COPY . .
WORKDIR "/src/XUCore.Net5.Template"
RUN dotnet build "XUCore.Net5.Template.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "XUCore.Net5.Template.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet","XUCore.Net5.Template.WebApi.dll","--environment","Development"]

#配置启动端口
ENV ASPNETCORE_URLS http://+:80