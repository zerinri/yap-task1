import React, { Fragment } from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import AddRecipePage from "../Pages/AddRecipePage/AddRecipePage";
import CategoryListPage from "../Pages/ListPages/CategoryListPage";
import LoginPage from "../Pages/LoginPage/LoginPage";
import ViewRecipePage from "../Pages/ViewRecipePage/ViewRecipePage";
import RecipeListPage from "../Pages/ListPages/RecipeListPage";
import {  useSelector } from "react-redux";

function MainRouter() {
  const loginState = useSelector((state) => state.login.loginState);

  return (
    <Fragment>
      <BrowserRouter>
        <Routes>
          <Route index element={<LoginPage />} />
          {loginState && (
            <>
              <Route path="/categories" element={<CategoryListPage />} />
              <Route path="/categories/:id" element={<RecipeListPage />} />
              <Route path="/addRecipe" element={<AddRecipePage />} />
              <Route path="/viewRecipe/:id" element={<ViewRecipePage />} />
              <Route path="/viewRecipe/:search" element={<ViewRecipePage />} />
            </>
          )}
        </Routes>
      </BrowserRouter>
    </Fragment>
  );
}

export default MainRouter;
