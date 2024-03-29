import React, { ChangeEvent } from "react";
import { useForm, useFormState, SubmitHandler } from "react-hook-form";
import { DataContext } from "../context";
import { GraphFormLoading } from "./graph-form-loading";
import { apiService, alertService } from "../_services";

const GraphForm = () => {
  const {
    register,
    handleSubmit,
    setValue,
    formState: { errors },
  } = useForm();

  const graphContext = React.useContext(DataContext);

  //state for selectecting item

  const [valueState, setValueState] = React.useState({
    itemId: 0,
    itemName: "",
    price: 0, // price for one item PED
    purchasePrice: 0, // price in %
    markup: 0, //PED
    beginQuantity: 0,
    quantity: 0,
    step: 0,
    selected: true,
  });

  //handle changed selected item
  const selectChange = (event) => {
    const value = event.target.value;
    graphContext.setScrollTo("");
    const index = graphContext.items.findIndex((obj) => {
      return obj.id === parseInt(value);
    });

    setValue("price", graphContext.items[index].cost);
    setValue("purchasePrice", graphContext.items[index].purchasePrice);
    setValue("beginQuantity", graphContext.items[index].beginQuantity);
    setValue("quantity", graphContext.items[index].quantity);
    setValue("step", graphContext.items[index].step);
    setValue("markup", graphContext.items[index].markup);

    graphContext.setSelectedItem(graphContext.items[index]);
  };

  React.useEffect(() => {
    if (graphContext.selectedItem) {
      setValueState(graphContext.selectedItem);
    }
  }, [graphContext.selectedItem]);

  // handle react state fields
  const onChange = (evt) => {
    const value = evt.currentTarget.value;
    let convertedValue = Number(value);
    graphContext.setScrollTo("");

    if (convertedValue) {
      setValueState({
        ...valueState,
        [evt.currentTarget.id]: convertedValue,
      });
    } else {
      setValueState({
        ...valueState,
        [evt.currentTarget.id]: value,
      });
    }
  };

  // submit form
  const onSubmit = (data) => {
    const itemIndex = graphContext.items.findIndex(
      (item) => item.id === valueState.id
    );

    graphContext.items[itemIndex] = valueState;
    // graphContext.setItems(graphContext.items);
    graphContext.setSelectedItem(valueState);
    apiService.modifyUserItems(valueState.id, valueState);
  };

  /* <-- Section -->   */
  if (graphContext.userItemsLoading) {
    return <GraphFormLoading />;
  } else
    return (
      <section className="section pt-0">
        <div className="container-md">
          <div className="row justify-content-center">
            <div className="col-10">
              <div className="card bg-primary shadow-soft border-light p-4">
                <form onSubmit={handleSubmit(onSubmit)}>
                  <div className="row">
                    <div className=" col-lg-6 px-md-0 mb-4 mb-lg-0">
                      <div className=" px-3">
                        <div className="row form-group">
                          <div className="col">
                            <label>Item</label>
                            <select
                              className="custom-select"
                              onChange={selectChange}
                            >
                              {graphContext?.items.map(
                                (item) =>
                                  item.selected && (
                                    <option key={item.id} value={item.id}>
                                      {item.name}
                                    </option>
                                  )
                              )}
                            </select>
                          </div>
                        </div>
                        <div className="row form-group">
                          <div className="col">
                            <label
                              className={
                                errors.cost && "text-danger font-weight-bold"
                              }
                            >
                              Value
                            </label>
                            <input
                              className="form-control"
                              id="price"
                              value={valueState.price}
                              readOnly
                            />
                          </div>
                          <div className="col">
                            <label
                              className={
                                errors.purchasePrice &&
                                "text-danger font-weight-bold"
                              }
                            >
                              Purchase price
                            </label>
                            <input
                              className="form-control"
                              id="purchasePrice"
                              type="number"
                              step="0.01"
                              {...register("purchasePrice", {
                                required: true,
                                min: 10.0,
                              })}
                              value={valueState.purchasePrice}
                              onChange={onChange}
                            />
                          </div>
                        </div>
                        {Object.keys(errors).length !== 0 && (
                          <span className="text-danger">
                            These field must be correct
                          </span>
                        )}
                      </div>
                    </div>

                    <div className=" col-lg-6 px-md-0 mb-4 mb-lg-0">
                      <div className=" px-3">
                        <div className="row form-group">
                          <div className="col">
                            <label
                              className={
                                errors.beginQuantity &&
                                "text-danger font-weight-bold"
                              }
                            >
                              Begin quantity
                            </label>
                            <input
                              type="number"
                              className="form-control"
                              id="beginQuantity"
                              {...register("beginQuantity", {
                                required: true,
                                min: 1,
                              })}
                              onChange={onChange}
                              value={valueState.beginQuantity}
                            />
                          </div>

                          <div className="col">
                            <label
                              className={
                                errors.quantity &&
                                "text-danger font-weight-bold"
                              }
                            >
                              Quantity
                            </label>
                            <input
                              className="form-control"
                              id="quantity"
                              type="number"
                              {...register("quantity", {
                                validate: {
                                  required: (value) => {
                                    if (
                                      value <= valueState.beginQuantity ||
                                      (value - valueState.beginQuantity) /
                                        valueState.step >
                                        500
                                    )
                                      return "Should be more than Begin Quantity and less than 500 point";
                                    return true;
                                  },
                                },
                                required: true,
                                min: 1,
                                valueAsNumber: true,
                              })}
                              onChange={onChange}
                              value={valueState.quantity}
                            />
                            <span className="text-danger">
                              {errors.quantity?.message}
                            </span>
                          </div>

                          <div className="col">
                            <label
                              className={
                                errors.step && "text-danger font-weight-bold"
                              }
                            >
                              Step
                            </label>
                            <input
                              className="form-control"
                              id="step"
                              type="number"
                              {...register("step", {
                                required: true,
                                min: 1,
                                valueAsNumber: true,
                              })}
                              onChange={onChange}
                              value={valueState.step}
                            />
                          </div>
                        </div>

                        <div className="row form-group">
                          <div className="col">
                            <label
                              className={
                                errors.markup && "text-danger font-weight-bold"
                              }
                            >
                              Markup
                            </label>
                            <input
                              className="form-control"
                              id="markup"
                              type="number"
                              {...register("markup", {
                                required: true,
                                min: 1,
                                valueAsNumber: true,
                              })}
                              onChange={onChange}
                              value={valueState.markup}
                            />
                          </div>

                          <div className="col align-self-end">
                            <button
                              className="btn btn-primary text-success  btn-block"
                              type="submit"
                            >
                              Submit
                            </button>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </form>
              </div>
            </div>
          </div>
        </div>
      </section>
    );
  /* <-- End of Section -->   */
};

export default GraphForm;
