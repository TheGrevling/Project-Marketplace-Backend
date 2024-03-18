# Project-Marketplace-Backend
the backend repository of Group 4.


Frontend: https://github.com/TheGrevling/Project-Marketplace-Frontend

Appsettings template:
```
"SiteSettings": {
    "AdminEmail": "example@test.com",
    "AdminPassword": "administrator"
},

"JwtTokenSettings": {
    "ValidIssuer": "ExampleIssuer",
    "ValidAudience": "ExampleAudience",
    "SymmetricSecurityKey": "v89h3bh89vh9ve8hc89nv98nn899cnccn998ev80vi809jberh89b",
    "JwtRegisteredClaimNamesSub": "rbveer3h535nn3n35nyny5umbbt"
},

"Logging": {
    "LogLevel": {
        "Default": "Information",
        "Microsoft.AspNetCore": "Warning"
    }
},
"AllowedHosts": "*",
"ConnectionStrings": {
    "DefaultConnectionString": "Host=HOSTNAME; Database=DEFAULTNAME; Username=DEFAULTNAME; Password=PASSWORD;"
}
```

Command to update database in latest migration:
```
update-database
```

Dependencies:
```
install-package nunit
install-package NUnit3TestAdapterworkCore
Install-Package Microsoft.AspNetCore.OpenApi
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL
```
