# Identity Forge

![GitHub last commit](https://img.shields.io/github/last-commit/gasbrieo/identity-forge)

A **modern authentication playground** built to explore **identity management, OAuth flows, and clean architecture patterns** with a **fullstack setup**.

---

## ✨ What is this?

**identity-forge** is a learning & experimentation project focused on:

- ✅ Exploring **authentication flows** (OAuth, Magic Links, Passwordless)
- ✅ Practicing **Clean Architecture** patterns on the backend
- ✅ Building a **SPA with React, TanStack Router & Query**
- ✅ Integrating **frontend & backend identity handling**
- ✅ Testing **CI/CD pipelines & semantic release**

---

## 🧱 Tech Stack

| Layer    | Stack                                                 |
| -------- | ----------------------------------------------------- |
| Frontend | React 19, Vite, TanStack Router & Query, Tailwind CSS |
| Backend  | .NET 9, Clean Architecture                            |
| Auth     | OAuth2, Magic Links                                   |
| CI/CD    | GitHub Actions + semantic-release                     |
| Quality  | ESLint, Prettier, Vitest, SonarCloud                  |

---

## 📂 Project Structure

The repo is split into **frontend** and **backend**, each with its own README:

```
/frontend   → Vite SPA (React + TanStack + Tailwind)
/backend    → .NET API with Clean Architecture
```

Each folder contains its **own setup & usage details**.

---

## 🚀 Getting Started

Clone the repo:

```bash
git clone https://github.com/gasbrieo/identity-forge.git
cd identity-forge
```

Then follow the instructions in:

- [`/frontend/README.md`](./frontend/README.md) for the SPA
- [`/backend/README.md`](./backend/README.md) for the API

---

## 🔄 Releases & Versioning

This project uses **[semantic-release](https://semantic-release.gitbook.io/semantic-release/)** for fully automated versioning:

- **feat:** → minor version bump (0.x.0 → 0.(x+1).0)
- **fix:** → patch version bump (0.0.x → 0.0.(x+1))
- **feat!: / BREAKING CHANGE:** → major version bump (x.0.0 → (x+1).0.0)

Every merge into `main` automatically:

- Updates `CHANGELOG.md`
- Creates a GitHub release

---

## 🪪 License

This project is licensed under the MIT License – see [LICENSE](LICENSE) for details.
