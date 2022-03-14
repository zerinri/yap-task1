import React, { Fragment, useEffect, useState } from "react";
import MainGridComponent from "../../components/MainGrid/MainGridComponent";
import axios from "axios";
import { useParams } from "react-router-dom";
import { Button, TextField } from "@mui/material";
import Navbar from "../../navbar/Navbar";

function RecipeListPage() {
  const recipeObject = { title: "Recipes:", hrefLocation: "/viewRecipe/" };
  const person = [{ firstName: "jaja" }, { firstName: "Pica" }];
  const [responseData, setResponseData] = useState([]);
  const [search, setSearch] = useState("");
  const { id } = useParams();

  useEffect(() => {
    axios
      .get(`https://localhost:5001/api/Recipe/GetRecipeByCategoryId/${id}`)
      .then((res) => {
        const allRecipes = res.data.data;
        setResponseData(allRecipes);
      });
  }, [id]);

  const searchByRecipe = () => {
    axios
      .get(`https://localhost:5001/api/Recipe/GetRecipeBySearch/${search}`)
      .then((res) => {
        const allRecipes = res.data.data;
        setResponseData(allRecipes);
      });
  };

  return (
    <Fragment>
      <Navbar />
      <br />
      <div
        style={{ float: "right", marginRight: "60px", marginBottom: "-30px" }}
      >
        <TextField
          label="Search"
          onChange={(e) => setSearch(e.target.value)}
        ></TextField>
        <Button style={{ marginTop: "10px",marginLeft:"10px" }} onClick={() => searchByRecipe()}>
          Search
        </Button>
      </div>
      <MainGridComponent
        setResponseData={setResponseData}
        defaultObject={recipeObject}
        person={person}
        responseData={responseData}
      />
    </Fragment>
  );
}

export default RecipeListPage;
