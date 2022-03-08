import React, { Fragment } from "react";
import CategoriesComponent from "../components/CategoriesComponent";

function RecipeListPage() {
  const recipeObject = {title:"Recipes:",hrefLocation:"/viewRecipe/"}
  const person = [{ firstName: "jaja" }, { firstName: "Pica" }];

  return (
    <Fragment>
      <CategoriesComponent defaultObject={recipeObject} person={person}/>
    </Fragment>
  );
}

export default RecipeListPage;
