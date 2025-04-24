import { ReactNode } from "react";
import { Navigate } from "react-router";
import { useUserStore } from "../../stores/useUserStore";

function ProtectedRoute({ children }: { children: ReactNode }) {
  const { user } = useUserStore();
  const isAuthenticated = user ? true : false;

  if (!isAuthenticated) {
    return <Navigate to="/" replace />;
  }

  return children;
}

export default ProtectedRoute;
