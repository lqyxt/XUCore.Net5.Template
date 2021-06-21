# XUCore.Net5.Template
XUCore.Net5.Template

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

3、启动容器

```bash

docker run --name my-test -d -p 8090:8090 mytest:0.0.1

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

