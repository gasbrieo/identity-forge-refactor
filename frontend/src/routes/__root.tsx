import type { QueryClient } from "@tanstack/react-query";
import { ReactQueryDevtools } from "@tanstack/react-query-devtools";
import { createRootRouteWithContext, Outlet } from "@tanstack/react-router";
import { TanStackRouterDevtools } from "@tanstack/react-router-devtools";

const RootComponent = () => (
  <>
    <Outlet />
    <TanStackRouterDevtools position="bottom-right" />
    <ReactQueryDevtools buttonPosition="bottom-left" />
  </>
);

interface RouteContext {
  queryClient: QueryClient;
}

export const Route = createRootRouteWithContext<RouteContext>()({
  component: RootComponent,
});
