# 🧠 Backend — IdentityForge

![Sonar Quality Gate](https://img.shields.io/sonar/quality_gate/gasbrieo_identity-forge_backend?server=http%3A%2F%2Fsonarcloud.io)
![Sonar Coverage](https://img.shields.io/sonar/coverage/gasbrieo_identity-forge_backend?server=https%3A%2F%2Fsonarcloud.io)

---

## ✨ Overview

This backend powers the **Identity Forge** authentication playground, focusing on modern identity management, OAuth flows, and clean architecture patterns.

- Built with **.NET 9**
- Implements **Clean Architecture** for maintainability and scalability
- Integrates with the frontend SPA for seamless identity handling
- Designed for learning, experimentation, and best practices

---

## 🧱 Tech Stack

- **Framework:** .NET 9
- **Architecture:** Clean Architecture
- **Authentication:** OAuth2, Magic Links
- **Testing:** xUnit
- **Test Containers:** Used for integration tests
- **CI/CD:** GitHub Actions + semantic-release
- **Quality:** SonarCloud

---

## 📂 Project Structure

- `/src` — Main API source code
- `/tests` — Unit, Integration and Acceptance tests 

---

## 📄 Documentation

For detailed technical documentation, flow diagrams (e.g., Login, Registration, Update), and architecture decisions, see the [`/docs`](./docs) folder.

---

## 🚀 Getting Started

1. **Restore dependencies:**
    ```sh
    dotnet restore
    ```

2. **Build the project:**
    ```sh
    dotnet build
    ```

3. **Run tests:**
    ```sh
    dotnet test
    ```

---

## 🔄 Releases & Versioning

This backend uses **semantic-release** for automated versioning and release management.  
Every merge into `main`:
- Updates `CHANGELOG.md`
- Creates a GitHub release

See [CONTRIBUTING.md](../CONTRIBUTING.md) for details on commit conventions and contributing.

---

## 🪪 License

This project is licensed under the MIT License – see [LICENSE](../LICENSE) for details.
