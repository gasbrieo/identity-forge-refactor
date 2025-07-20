import { createFileRoute } from "@tanstack/react-router";

const LandingPage = () => {
  return <main className="bg-background min-h-screen">Hello world!</main>;
};

export const Route = createFileRoute("/")({
  component: LandingPage,
});
