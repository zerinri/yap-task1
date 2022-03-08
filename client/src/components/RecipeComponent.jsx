import React, { Fragment, useState } from "react";
import Navbar from "../navbar/Navbar";
import RecipeBoxComponent from "./RecipeBoxComponent";
import { Container } from "@mui/material";
import { recipeContainer } from "./RecipeComponentStyle";
import IngredientBoxComponent from "./IngredientBoxComponent";

function AddRecipePage({ viewPage, defaultRecipeObject }) {
  const [ingredientArray, setIngredientArray] = useState([]);

  console.log(ingredientArray);
  return (
    <Fragment>
      <Navbar />
      <Container maxWidth="hg" sx={recipeContainer}>
        <RecipeBoxComponent
          viewPage={viewPage}
          defaultRecipeObject={defaultRecipeObject}
          ingredientArray={ingredientArray}
          setIngredientArray={setIngredientArray}
        />
        <IngredientBoxComponent
          viewPage={viewPage}
          defaultRecipeObject={defaultRecipeObject}
          ingredientArray={ingredientArray}
          setIngredientArray={setIngredientArray}
        />
      </Container>
    </Fragment>
  );
}

export default AddRecipePage;
