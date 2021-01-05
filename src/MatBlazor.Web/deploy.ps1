docker build -t matblazor_deploy -f deploy.df .
docker run -it --rm matblazor_deploy cat /MatBlazor/wwwroot/dist/matBlazor.js | Set-Content -Encoding ASCII ..\MatBlazor\wwwroot\dist\matBlazor.js
docker run -it --rm matblazor_deploy cat /MatBlazor/wwwroot/dist/matBlazor.css | Set-Content -Encoding ASCII ..\MatBlazor\wwwroot\dist\matBlazor.css
