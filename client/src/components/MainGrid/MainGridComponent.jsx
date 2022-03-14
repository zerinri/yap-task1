import React from "react";
import { Grid, Container, Typography, Button } from "@mui/material";
import { Fragment } from "react";
import GridComponent from "../GridComponent/GridComponent";

import {
  categoryGrid,
  categoryContainer,
  categoryButton,
} from "./MainGridStyle";

function MainGridComponent({ defaultObject, responseData }) {
  return (
    <Fragment>
      <Container maxWidth="hg" sx={categoryContainer}>
        <Typography sx={{ marginTop: "10px" }} textAlign="left" variant="h4">
          {defaultObject.title}
        </Typography>
        <Grid sx={categoryGrid} container spacing={2}>
          {responseData.length ? (
            responseData.map((item) => (
              <GridComponent
                defaultObject={defaultObject}
                totalCost={item.totalCost}
                name={item.name}
                key={item.id}
                id={item.id}
              />
            ))
          ) : (
            <Typography sx={{ marginTop: "250px" }} variant="h4">
              Loading...
            </Typography>
          )}
        </Grid>
        {responseData.length ? (
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

export default MainGridComponent;
