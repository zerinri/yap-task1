import React, { Fragment, useEffect, useState } from "react";
import {
  Grid,
  Container,
  Typography,
  TextField,
  Select,
  MenuItem,
  FormControl,
  List,
  InputLabel,
  ListItem,
  ListItemText,
  Button,
  Divider,
  Snackbar,
} from "@mui/material";
import {
  recipeGrid,
  recipeList,
  recipeTextField,
  recipeContainerTwo,
  recipeContainerTotalCost,
} from "./RecipeComponentStyle";
import { Box } from "@mui/system";

function RecipeBoxComponent({
  viewPage,
  ingredientArray,
  setIngredientArray,
  defaultRecipeObject,
}) {
  const [nameOfRecipe, setNameofRecipe] = useState("");
  const [categoryRecipe, setCategoryRecipe] = useState("");
  const [descriptionRecipe, setDescriptionRecipe] = useState("");
  const [totalCost, setTotalCost] = useState(0);
  const [recipeArray, setRecipeArray] = useState([]);
  const [openSnack, setOpenSnack] = useState(false);

  const handleChangeCategory = (event) => {
    setCategoryRecipe(event.target.value);
  };

  console.log(ingredientArray);

  const kg = 1
  const mg = 0.10
  const g = 0.001

  useEffect(() => {
    function calculate() {
      ingredientArray.map((item) => {
        if (item.unitMeasure === "g") {
          setTotalCost(totalCost + +(item.quantity));
        }
      });
    }
    calculate();
  }, [ingredientArray]);

  const addDetails = (e) => {
    e.preventDefault();
    const recipeAdd = {
      nameOfRecipe: nameOfRecipe,
      categoryRecipe: categoryRecipe,
      descriptionRecipe: descriptionRecipe,
      ingredientArray: ingredientArray,
    };
    if (ingredientArray.length == 0) {
      return setOpenSnack(true);
    }
    setRecipeArray(recipeAdd);
    setNameofRecipe("");
    setCategoryRecipe("");
    setDescriptionRecipe("");
    setIngredientArray([]);
  };
  return (
    <Fragment>
      <Snackbar
        open={openSnack}
        onClose={() => setOpenSnack(false)}
        autoHideDuration={4000}
        message="Ingredient list is empty, please add at least 1 ingredient !!"
      />
      <Box sx={{ marginBottom: "50px" }} component="form" onSubmit={addDetails}>
        <Typography sx={{ marginTop: "10px" }} textAlign="left" variant="h4">
          {defaultRecipeObject.title}
        </Typography>
        <Grid container spacing={2} sx={{ marginTop: "20px", width: "100%" }}>
          <Grid item xs={6}>
            <TextField
              required
              disabled={viewPage}
              sx={{ width: "90%" }}
              label="Name of the recipe:"
              value={nameOfRecipe}
              onChange={(e) => setNameofRecipe(e.target.value)}
            />
          </Grid>
          <Grid item xs={6}>
            <FormControl sx={{ width: "90%" }}>
              <InputLabel id="demo-simple-select-label">Category</InputLabel>
              <Select
                required
                disabled={viewPage}
                labelId="demo-simple-select-label"
                id="demo-simple-select"
                value={categoryRecipe}
                label="Category"
                onChange={handleChangeCategory}
              >
                <MenuItem value={10}>Ten</MenuItem>
                <MenuItem value={20}>Twenty</MenuItem>
                <MenuItem value={30}>Thirty</MenuItem>
              </Select>
            </FormControl>
          </Grid>
        </Grid>
        <Divider sx={{ marginTop: "20px" }} />
        <Grid container spacing={2} sx={recipeGrid}>
          <Grid item xs={6}>
            <TextField
              required
              disabled={viewPage}
              value={descriptionRecipe}
              sx={recipeTextField}
              onChange={(e) => setDescriptionRecipe(e.target.value)}
              label="Description"
              multiline
              rows={10}
            />
          </Grid>
          <Grid item xs={6}>
            <Container sx={recipeContainerTwo}>
              <Typography variant="h5">Ingredient list</Typography>
              <List sx={recipeList}>
                {ingredientArray.map((item, index) => (
                  <ListItem key={index}>
                    <ListItemText
                      secondary="Ingredient"
                      primary={item.nameOfIngredient}
                    />
                    <ListItemText
                      secondary={item.unitMeasure}
                      primary={item.quantity}
                    />
                  </ListItem>
                ))}
              </List>
            </Container>
            <Container sx={recipeContainerTotalCost}>
              Total cost: {totalCost}$
            </Container>
            {!viewPage && (
              <Button
                type="submit"
                sx={{ marginTop: "15px" }}
                variant="contained"
              >
                Add Recipe
              </Button>
            )}
            {viewPage && (
              <Button
                href="/addRecipe"
                sx={{ marginTop: "15px" }}
                variant="contained"
              >
                Add recipe
              </Button>
            )}
          </Grid>
        </Grid>
      </Box>
    </Fragment>
  );
}

export default RecipeBoxComponent;
