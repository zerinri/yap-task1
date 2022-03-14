import React, { Fragment, useState, useLayoutEffect } from "react";
import Navbar from "../../navbar/Navbar";
import { useParams } from "react-router-dom";
import {
  Grid,
  Container,
  Typography,
  TextField,
  List,
  ListItem,
  ListItemText,
  Divider,
} from "@mui/material";
import axios from "axios";
import {
  recipeGrid,
  recipeList,
  recipeTextField,
  recipeContainerTwo,
  recipeContainerTotalCost,
  recipeContainer,
} from "./ViewRecipeStyle";

function ViewRecipePage() {
  const { id } = useParams();
  const [responseData, setResponseData] = useState([]);
  const viewPage = true;


  useLayoutEffect(() => {
    axios
      .get(`https://localhost:5001/api/Recipe/GetRecipeById/${id}`)
      .then((res) => {
        const allRecipes = res.data.data;
        setResponseData(allRecipes);
      });
  }, []);

  const defaultRecipeObject = { title: "View Recipe:" };
  return (
    <Fragment>
      <Navbar />
      <Container maxWidth="hg" sx={recipeContainer}>
        <Typography sx={{ marginTop: "10px" }} textAlign="left" variant="h4">
          Name: {responseData.name}
        </Typography>
        <br />
        <Typography textAlign="left" variant="h6">
          Category: {responseData.category}
        </Typography>
        <Divider sx={{ marginTop: "20px" }} />
        <Grid container spacing={2} sx={recipeGrid}>
          <Grid item xs={6}>
          <Typography variant="h5">Description</Typography>
            <TextField
              disabled={viewPage}
              defaultValue={responseData.description}
              sx={recipeTextField}
              multiline
              rows={10}
            />
          </Grid>
          <Grid item xs={6}>
            <Container sx={recipeContainerTwo}>
              <Typography variant="h5">Ingredient list</Typography>
              <List sx={recipeList}>
                {responseData.ingredients ? (
                  responseData.ingredients.map((item) => (
                    <ListItem key={item.id}>
                      <ListItemText
                        secondary="Ingredient"
                        primary={item.name}
                      />
                      <ListItemText
                        secondary={item.unitMeasure}
                        primary={item.purchaseQuantity}
                      />
                    </ListItem>
                  ))
                ) : (
                  <Typography sx={{ marginTop: "50px" }} variant="h4">
                    Loading...
                  </Typography>
                )}
              </List>
            </Container>
            <Container sx={recipeContainerTotalCost}>Total cost: {responseData.totalCost}KM</Container>
          </Grid>
        </Grid>
      </Container>
    </Fragment>
  );
}

export default ViewRecipePage;
