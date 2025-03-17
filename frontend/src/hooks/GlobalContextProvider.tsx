import { useState } from "react";
import { User, UserContext } from "./useGlobalContext";

const defaultUser: User = {
  userId: "0",
  userName: "",
  firstName: "",
  lastName: "",
};

export default function GlobalContext({
  children,
}: {
  children: React.ReactNode;
}) {
  const [user, setUser] = useState<User | null>(null);

  return (
    <UserContext.Provider
      value={{
        user: user || defaultUser,
        setUser,
      }}
    >
      {children}
    </UserContext.Provider>
  );
}
