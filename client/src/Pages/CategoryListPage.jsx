import React, { Fragment } from "react";
import CategoriesComponent from "../components/CategoriesComponent";

function CategoryListPage() {
 const categoryObject = {title:"Categories:",hrefLocation:"/categories/"}
 const person = [{ firstName: "Dorucak" }, { firstName: "Rucak" }];
  return (
    <Fragment>
      <CategoriesComponent defaultObject={categoryObject} person={person}/>
    </Fragment>
  );
}

export default CategoryListPage;
