import React, { Fragment, useState } from "react";
import Navbar from "../../navbar/Navbar";
import RecipeBoxComponent from "../../components/BoxComponents/RecipeBoxComponent";
import { Container } from "@mui/material";
import { recipeContainer } from "./AddRecipeStyle";
import IngredientBoxComponent from "../../components/BoxComponents/IngredientBoxComponent";

function AddRecipePage({ responseData }) {
  const [ingredientArray, setIngredientArray] = useState([]);

  return (
    <Fragment>
      <Navbar />
      <Container maxWidth="hg" sx={recipeContainer}>
        <RecipeBoxComponent
          responseData={responseData}
          ingredientArray={ingredientArray}
          setIngredientArray={setIngredientArray}
        />
        <IngredientBoxComponent
          ingredientArray={ingredientArray}
          setIngredientArray={setIngredientArray}
        />
      </Container>
    </Fragment>
  );
}

export default AddRecipePage;
