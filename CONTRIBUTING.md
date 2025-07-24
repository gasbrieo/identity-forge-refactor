# Contributing to Identity Forge

Thank you for considering contributing! 🎉  
This project follows **Conventional Commits** and uses **semantic-release** for fully automated versioning and publishing.

---

## 🛠 How to Contribute

1. **Fork & clone** the repository
2. Restore dependencies for the relevant part (frontend or backend):

   - **Backend (.NET):**
     ```sh
     dotnet restore
     ```
   - **Frontend (Node):**
     ```sh
     npm install
     ```

3. Build & run tests:

   - **Backend:**
     ```sh
     dotnet build
     dotnet test
     ```
   - **Frontend:**
     ```sh
     npm run build
     npm test
     ```

4. Create a feature branch:
    ```sh
    git checkout -b feat/your-feature-name
    ```

5. Make your changes and commit using **Conventional Commits** (see below)
6. Push your branch and open a Pull Request 🎉

---

## 📝 Conventional Commits

We use **Conventional Commits** so semantic-release can automatically bump versions and publish releases.

### ✅ Examples

- **feat:** adds a new feature → _minor version bump_
    ```
    feat: add OAuth2 support to backend
    ```
- **fix:** bug fix → _patch version bump_
    ```
    fix: correct login redirect issue
    ```
- **feat!:** or add `BREAKING CHANGE:` in the body → _major version bump_
    ```
    feat!: refactor authentication flow

    BREAKING CHANGE: Magic Link flow was replaced with OAuth2
    ```

### ❌ Avoid

- Messages like `update stuff` or `fix bug`
- Commits without context

---

## 🔄 What Happens After Merge?

When you merge into **main**:

- semantic-release analyzes commits
- Decides the next version (patch/minor/major)
- Updates `CHANGELOG.md` automatically
- Creates a GitHub Release
- **Publishes new versions automatically** 🎉

No manual versioning or tagging is needed!

---

## ✅ Commit Types

| Type     | When to use                                                |
| -------- | ---------------------------------------------------------- |
| feat     | A new feature                                              |
| fix      | A bug fix                                                  |
| docs     | Documentation only changes                                 |
| style    | Code style changes (formatting, missing semi-colons, etc.) |
| refactor | Code change that neither fixes a bug nor adds a feature    |
| test     | Adding or fixing tests                                     |
| chore    | Maintenance tasks (build, tooling, CI, etc.)               |

---

## 📦 Releasing

Releases are **fully automated** via GitHub Actions + semantic-release.  
Just merge your PR, and everything else happens automatically.

---

Thanks for contributing! 🚀
