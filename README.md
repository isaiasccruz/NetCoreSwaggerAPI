# NetCoreSwaggerAPI
Exemplo de uma API RESTful usando o Swagger da OpenAPI que faz algumas operações matemáticas simples e está pronta para rodar em container.
O deploy da aplicação foi feito em testes em um ambiente Docker em Ubuntu 18.04.

O Dockerfile já está preparado pela solution e a imagem é construida com sucesso:

~~~
#10 exporting to image
#10 sha256:e8c613e07b0b7ff33893b694f7759a10d42e180f2b4dc349fb57dc6b71dcab00
#10 exporting layers 0.0s done
#10 writing image sha256:de3f3ce496307803328409ad549a7a46429c34004508941bf376f762930016c9 done
#10 DONE 0.1s

$ docker image ls
REPOSITORY          TAG       IMAGE ID       CREATED          SIZE
netcoreswaggerapi   v1        de3f3ce49630   21 seconds ago   208MB
~~~

O projeto todo foi desenvolvido no VisualStudio 2019.

Para rodar o projeto caso não seja feito via deploy, voce pode publicar no modo tradicional em um Windows Server com IIS ou apenas rodar a aplicação em Debug no VisualStudio

##Edit 05/02/2020 Criação de uma aplicação console com menu para consumir todas os métodos da API
A aplicação foi adicionada a solution
