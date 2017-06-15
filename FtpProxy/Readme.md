FROM microsoft/dotnet:runtime
WORKDIR /dotnetapp
COPY out .
ENTRYPOINT ["dotnet", "dotnetapp.dll"]




   



Prerequisities    PROD

Setting up target environment:

        [Windows]
            setup target environment *setx PARAGRAPH_58 "PROD" /M*

        [Linux]