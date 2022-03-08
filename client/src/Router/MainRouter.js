import React, { Fragment } from "react";
import { BrowserRouter,Route,Routes } from "react-router-dom";
import AddRecipePage from "../Pages/AddRecipePage";
import CategoryListPage from "../Pages/CategoryListPage"
import LoginPage from "../Pages/LoginPage"
import ViewRecipePage from "../Pages/ViewRecipePage";
import RecipeListPage from "../Pages/RecipeListPage";

function MainRouter() {
  return (
    <Fragment>
      <BrowserRouter>
        <Routes>
        <Route index element={<LoginPage />} />
          <Route path="/categories" element={<CategoryListPage />}/>
          <Route path="/categories/:list" element={<RecipeListPage />}/>
          <Route path="/addRecipe" element={<AddRecipePage />} />
          <Route path="/viewRecipe/:recipe" element={<ViewRecipePage />} />
        </Routes>
      </BrowserRouter>
    </Fragment>
  );
}

export default MainRouter;
