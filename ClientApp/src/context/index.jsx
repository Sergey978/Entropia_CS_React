import React, { useState, useEffect, useRef } from "react";
import { apiService } from "../_services";

export const DataContext = React.createContext(null);

const GraphDataProvider = ({ children }) => {
  const [items, setItems] = React.useState([]);
  const [selectedItem, setSelectedItem] = React.useState({
    itemId: 0,
    itemName: "Item wasn't selected",
    price: 0, // price for one item PED
    purchasePrice: 0, // price in %
    markup: 0, //PED
    beginQuantity: 0,
    quantity: 0,
    step: 0,
    selected: false,
  });
  const [table, setTable] = React.useState([]);
  const [userItemsLoading, setUserItemsLoading] = useState(true);
  const [scrollTo, setScrollTo] = useState("");

  useEffect(() => {
    let cancelled = false;
    const doGetItems = async () => {
      if (!cancelled) {
        const items = [
          ...(await apiService.getUserStandartItems()),
          ...(await apiService.getCustomtItems()),
        ];
        setItems(items);
        if (items.length != 0) {
          setSelectedItem(items[0]);
        }
        setUserItemsLoading(false);
      }
    };
    doGetItems();
    return () => {
      cancelled = true;
    };
  }, []);

  // function for calculation and populate table
  const calcTable = () => {
    const tableRows = [];

    if (
      items.length != 0 &&
      selectedItem.beginQuantity !== 0 &&
      selectedItem.quantity !== 0 &&
      selectedItem.step !== 0
    ) {
      for (
        let i = selectedItem.beginQuantity;
        i <= selectedItem.quantity;
        i += selectedItem.step
      ) {
        let sellingPrice = Math.round(
          i * selectedItem.price + selectedItem.markup
        );
        let markup = sellingPrice - selectedItem.price * i;
        let tax = 0.5 + (markup * 99.5) / (1990 + markup);
        let profit =
          sellingPrice -
          (selectedItem.price * selectedItem.purchasePrice * i) / 100 -
          tax;

        tableRows.push({
          Quantity: i,
          Price: sellingPrice,
          Profit: profit,
          Tax: tax,
          Markup: (sellingPrice / (i * selectedItem.price)) * 100,
          IsSelected: false,
        });
      }
    }
    setTable([...tableRows]);
  };

  useEffect(() => {
    calcTable();
  }, [selectedItem]);

  //changing values in user's item
  const updateItem = (changedItem) => {
    const itemIndex = items.findIndex(
      (item) => item.itemId === changedItem.itemId
    );
    items[itemIndex] = changedItem;
    setItems(items);
  };

  //change row status for selected row
  // without spread array table  doesn't work !!!!
  const updateTable = (rowIndex) => {
    table.filter((tableRow) => {
      if (tableRow.Quantity === rowIndex) {
        tableRow.IsSelected = true;
      } else tableRow.IsSelected = false;
    });
    setTable([...table]);
  };

  return (
    <DataContext.Provider
      value={{
        items,
        setItems,
        selectedItem,
        setSelectedItem,
        table,
        updateTable,
        userItemsLoading,
        scrollTo,
        setScrollTo,
      }}
    >
      {children}
    </DataContext.Provider>
  );
};

export default GraphDataProvider;
