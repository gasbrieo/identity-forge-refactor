import { defineConfig } from "vitest/config";

import viteConfig from "./vite.config";

export default defineConfig({
  ...viteConfig,
  test: {
    globals: true,
    environment: "jsdom",
    setupFiles: "./src/tests/setupTests.ts",
    coverage: {
      reporter: ["lcov", "html"],
      include: ["src"],
    },
  },
});
