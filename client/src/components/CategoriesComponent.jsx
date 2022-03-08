import React from "react";
import { Grid, Container, Typography, Button } from "@mui/material";
import { Fragment } from "react";
import GridComponent from "./GridComponent";
import Navbar from "../navbar/Navbar";
import {
  categoryGrid,
  categoryContainer,
  categoryButton,
} from "./CategoriesComponentStyle";

function CategoriesComponent({ defaultObject, person }) {
  console.log(person)
  return (
    <Fragment>
      <Navbar />
      <Container maxWidth="hg" sx={categoryContainer}>
        <Typography sx={{ marginTop: "10px" }} textAlign="left" variant="h4">
          {defaultObject.title}
        </Typography>
        <Grid sx={categoryGrid} container spacing={2}>
          {person.length ? (
            person.map((item, index) => (
              <GridComponent defaultObject={defaultObject} name={item.firstName} key={index} />
            ))
          ) : (
            <Typography sx={{ marginTop: "100px" }} variant="h4">
              Loading...
            </Typography>
          )}
        </Grid>
        {person.length ? (
          <Button sx={categoryButton} variant="contained">
            Load More
          </Button>
        ) : (
          <></>
        )}
      </Container>
    </Fragment>
  );
}

export default CategoriesComponent;
