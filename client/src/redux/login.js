import { createSlice } from "@reduxjs/toolkit";

export const counterSlice = createSlice({
  name: "login",
  initialState: {
    loginState: false,
  },
  reducers: {
    setLoginState: (state, action) => {
      state.loginState = action.payload;
    },
  },
});
export const { setLoginState } = counterSlice.actions;

export default counterSlice.reducer;
