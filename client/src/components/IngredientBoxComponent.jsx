import React, { Fragment, useState } from "react";
import {
  Grid,
  TextField,
  Select,
  MenuItem,
  FormControl,
  InputLabel,
  Button,
} from "@mui/material";
import { Box } from "@mui/system";

function IngredientBoxComponent({
  viewPage,
  setIngredientArray,
  defaultRecipeObject,
}) {
  const [nameOfIngredient, setNameOfIngredient] = useState("");
  const [quantity, setQuantity] = useState(0);
  const [unitMeasure, setUnitMeasure] = useState("");
  const handleChangeUnitMeasure = (event) => {
    setUnitMeasure(event.target.value);
  };

  const addIngredient = (e) => {
    e.preventDefault();
    const ingridentAdd = {
      nameOfIngredient: nameOfIngredient,
      quantity: quantity,
      unitMeasure: unitMeasure,
    };
    setIngredientArray((recipeArray) => [...recipeArray, ingridentAdd]);
    setNameOfIngredient("");
    setQuantity("");
    setUnitMeasure("");
  };

  return (
    <Fragment>
      <Box component="form" onSubmit={addIngredient}>
        <Grid container spacing={2}>
          <Grid item xs={12}>
            <TextField
              value={nameOfIngredient}
              required
              disabled={viewPage}
              sx={{ width: "90%" }}
              label="Name of the ingredient:"
              onChange={(e) => setNameOfIngredient(e.target.value)}
            />
          </Grid>
          <Grid item xs={6}>
            <TextField
              required
              disabled={viewPage}
              sx={{ width: "80%" }}
              label="Quantity"
              value={quantity}
              type="number"
              onChange={(e) => setQuantity(e.target.value)}
            />
          </Grid>
          <Grid item xs={6}>
            <FormControl sx={{ width: "80%" }}>
              <InputLabel id="demo-simple-select-label">
                Unit Measure:
              </InputLabel>
              <Select
                required
                disabled={viewPage}
                labelId="demo-simple-select-label"
                id="demo-simple-select"
                value={unitMeasure}
                label="Unit Measure:"
                onChange={handleChangeUnitMeasure}
              >
                <MenuItem value={"g"}>g</MenuItem>
                <MenuItem value={"Mg"}>Mg</MenuItem>
                <MenuItem value={"Kg"}>Kg</MenuItem>
              </Select>
            </FormControl>
          </Grid>
        </Grid>
        {!viewPage && (
          <Button
            type="submit"
            sx={{ marginTop: "15px", marginBottom: "15px" }}
            variant="contained"
          >
            Add ingredient
          </Button>
        )}
      </Box>
    </Fragment>
  );
}

export default IngredientBoxComponent;
