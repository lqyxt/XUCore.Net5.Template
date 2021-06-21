# XUCore.Net5.Template

XUCore.Net5.Template（只使用插件化的框架，不使用集成式框架）

基于经典ddd的web、api代码模板。 


### 使用模板

本地安装模板：可详情见 `install-template.bat` 文件内

### 本地安装模板步骤：

如果已经装过旧版，可以先执行下面命令进行卸载：

```bash

dotnet new -u XUCore.Net5.Template

```

然后安装指定版本：

```bash

dotnet new --install XUCore.Net5.Template::0.0.2

```

### 创建项目

切换到指定创建的目录。

假设我们需要在 `d:\\test\MyTest` 创建，

那么先切换到该目录

```bash

cd d:\\test\MyTest

```

然后执行下面命令创建项目

```bash

dotnet new xucore-net5-template -n MyTest -o .

```

这里的 `xucore-net5-template` 是使用模板短名称。

`MyTest` 为新创建的项目名称。


![avatar](http://www.3624091.com/1.png)


### 本地构建项目镜像到Docker（如果使用jenkins可以直接在jenkins里配置）

前提是dockerfile需要放在项目根目录，而非启动项目的目录

1、切换到项目目录

```bash

cd d:\\test\MyTest

```

2、打包进本地容器

```bash

docker build -t mytest:0.0.1 .

```

从控制台中，我们可以看到打包过程

```bash

E:\MyTest>docker build -t mytest:0.0.1 .
[+] Building 14.7s (12/20)
 => [internal] load build definition from Dockerfile                                                               0.0s
 => => transferring dockerfile: 32B                                                                                0.0s
 => [internal] load .dockerignore                                                                                  0.0s
 => => transferring context: 2B                                                                                    0.0s
 => [internal] load metadata for mcr.microsoft.com/dotnet/sdk:5.0                                                  0.0s
[+] Building 15.1s (12/20)
 => [internal] load build definition from Dockerfile                                                               0.0s
[+] Building 30.4s (12/20)
 => [internal] load build definition from Dockerfile                                                               0.0s
 => => transferring dockerfile: 32B                                                                                0.0s
 => [internal] load .dockerignore                                                                                  0.0s
 => => transferring context: 2B                                                                                    0.0s
[+] Building 56.7s (21/21) FINISHED
 => [internal] load build definition from Dockerfile                                                               0.0s
 => => transferring dockerfile: 32B                                                                                0.0s
 => [internal] load .dockerignore                                                                                  0.0s
 => => transferring context: 2B                                                                                    0.0s
 => [internal] load metadata for mcr.microsoft.com/dotnet/sdk:5.0                                                  0.0s
 => [internal] load metadata for mcr.microsoft.com/dotnet/aspnet:5.0                                               0.0s
 => [build 1/7] FROM mcr.microsoft.com/dotnet/sdk:5.0                                                              0.0s
 => [internal] load build context                                                                                  1.2s
 => => transferring context: 119.91MB                                                                              1.2s
 => [base 1/5] FROM mcr.microsoft.com/dotnet/aspnet:5.0                                                            0.0s
 => CACHED [build 2/7] WORKDIR /src                                                                                0.0s
 => CACHED [build 3/7] COPY [MyTest.WebApi/MyTest.WebApi.csproj, MyTest.WebApi/]                                   0.0s
 => CACHED [build 4/7] RUN dotnet restore "MyTest.WebApi/MyTest.WebApi.csproj"                                     0.0s
 => [build 5/7] COPY . .                                                                                           0.4s
 => [build 6/7] WORKDIR /src/MyTest.WebApi                                                                         0.0s
 => [build 7/7] RUN dotnet build "MyTest.WebApi.csproj" -c Release -o /app/build                                  43.2s
 => [publish 1/1] RUN dotnet publish "MyTest.WebApi.csproj" -c Release -o /app/publish                            11.5s
 => CACHED [base 2/5] ADD [sources.list, /etc/apt/]                                                                0.0s
 => CACHED [base 3/5] RUN rm /etc/localtime                                                                        0.0s
 => CACHED [base 4/5] RUN ln -s /usr/share/zoneinfo/Asia/Shanghai /etc/localtime                                   0.0s
 => CACHED [base 5/5] WORKDIR /app                                                                                 0.0s
 => CACHED [final 1/2] WORKDIR /app                                                                                0.0s
 => CACHED [final 2/2] COPY --from=publish /app/publish .                                                          0.0s
 => exporting to image                                                                                             0.0s
 => => exporting layers                                                                                            0.0s
 => => writing image sha256:addb11051debc4cf74c7d048d15cafdb7edbf121ae54fc55960f1b46bce94fda                       0.0s
 => => naming to docker.io/library/mytest:0.0.1                                                                    0.0s
 => => #   Determining projects to restore...
Use 'docker scan' to run Snyk tests against images to find vulnerabilities and learn how to fix them

```

结束后，我们使用 `docker images` 查看打包好的镜像

```bash

E:\MyTest>docker images
REPOSITORY                        TAG       IMAGE ID       CREATED        SIZE
mytest                            0.0.1     addb11051deb   20 hours ago   258MB
mcr.microsoft.com/dotnet/sdk      5.0       1cfcb8589c29   12 days ago    631MB
mcr.microsoft.com/dotnet/aspnet   5.0       592a912e0dcb   12 days ago    205MB

```

3、启动容器

```bash

docker run --name my-test -d -p 8090:8090 mytest:0.0.1

```

启动后我们通过 `docker ps -a` 查看运行的镜像

```bash

E:\MyTest>docker ps -a
CONTAINER ID   IMAGE          COMMAND                  CREATED         STATUS                       PORTS     NAMES
35c9010404ae   mytest:0.0.1   "dotnet MyTest.WebAp…"   5 minutes ago   Exited (139) 4 minutes ago             my-test

```

4、浏览器访问

http://127.0.0.1:8090/swagger

此时容器会报错，因为在创建项目后配置文件内需要修改数据库连接地址（进入容器后，我们的所有数据库地址以及其他相关地址都需要修改为内网访问，或者公网访问）

我们可以查看容器的日志，方便我们定位错误

```bash

docker logs 35c9010404ae

```

此时，在容器日志，我们看到

```bash

fail: Microsoft.EntityFrameworkCore.Database.Connection[20004]
      An error occurred using the connection to database '' on server 'localhost'.
fail: Microsoft.EntityFrameworkCore.Database.Connection[20004]
      An error occurred using the connection to database '' on server 'localhost'.
fail: Microsoft.EntityFrameworkCore.Database.Connection[20004]
      An error occurred using the connection to database '' on server 'localhost'.
fail: Microsoft.EntityFrameworkCore.Database.Connection[20004]
      An error occurred using the connection to database '' on server 'localhost'.
fail: Microsoft.EntityFrameworkCore.Database.Connection[20004]
      An error occurred using the connection to database '' on server 'localhost'.
fail: Microsoft.EntityFrameworkCore.Database.Connection[20004]

```

