# 🧩 GitHub Repositories Search — ASP.NET Framework Backend

Backend service for searching GitHub repositories, managing bookmarks, and sending repository details via email.  
Built with **ASP.NET Web API** on **.NET Framework 4.7.2 / 4.8**.

---

## ⚙️ Requirements

- **Visual Studio** 2019 or 2022  
- **.NET Framework** 4.7.2 or 4.8  
- **NuGet Packages:**
  - `Microsoft.AspNet.WebApi`
  - `Newtonsoft.Json`
  - `System.IdentityModel.Tokens.Jwt`
  - `Microsoft.IdentityModel.Tokens`

---

## 🛠️ Configuration

1. Open **`web.config`** and set the following keys:

   ```xml
   <add key="JwtSecret" value="your-secret-key" />
   <add key="JwtIssuer" value="your-issuer" />
   <add key="JwtAudience" value="your-audience" />

   <add key="SmtpHost" value="smtp.server.com" />
   <add key="SmtpPort" value="587" />
   <add key="SmtpUser" value="user@domain.com" />
   <add key="SmtpPass" value="password" />
   <add key="SmtpFrom" value="noreply@domain.com" />
