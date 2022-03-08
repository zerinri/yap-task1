import React, { Fragment, useState } from "react";
import RecipeComponent from "../components/RecipeComponent";

function ViewRecipePage() {
  const defaultRecipeObject = { title: "View Recipe:" };
  return (
    <Fragment>
      <RecipeComponent
        viewPage={true}
        defaultRecipeObject={defaultRecipeObject}
      />
    </Fragment>
  );
}

export default ViewRecipePage;
