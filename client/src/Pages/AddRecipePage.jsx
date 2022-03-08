import React, { Fragment } from "react";
import RecipeComponent from "../components/RecipeComponent";

function AddRecipePage() {
  const defaultRecipeObject = { title: "Add Recipe:" };
  return (
    <Fragment>
      <RecipeComponent defaultRecipeObject={defaultRecipeObject}/>
    </Fragment>
  );
}

export default AddRecipePage;
