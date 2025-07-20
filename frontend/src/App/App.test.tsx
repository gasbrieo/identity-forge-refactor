import { render, screen } from "~/tests/testUtils";

import { App } from "./App";

describe("App", () => {
  it("should render properly", async () => {
    render(<App />);

    expect(await screen.findByText("Hello world!")).toBeInTheDocument();
  });
});
