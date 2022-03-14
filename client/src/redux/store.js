import { configureStore } from "@reduxjs/toolkit";
import categories from "./categories";
import login from "./login";

export const store = configureStore({
  reducer: {
    categories: categories,
    login: login,
  },
});
