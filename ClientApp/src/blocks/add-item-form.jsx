import React from "react";
import { useForm, SubmitHandler, useFormState } from "react-hook-form";
import { apiService } from "../_services";
//import { IItem } from '../../services/data-service';

export const AddItemForm = ({ _submitResult, _submited, _addFuncion }) => {
  const {
    register,
    handleSubmit,
    watch,
    formState: { errors },
  } = useForm();

  const onSubmit = async (data) => {
    const result = await _addFuncion({
      Name: data.Name,
      Price: data.price,
    });
    _submitResult(Boolean(result));
  };

  return (
    /* "handleSubmit" will validate your inputs before invoking "onSubmit" */
    <form onSubmit={handleSubmit(onSubmit)}>
      <fieldset disabled={_submited}>
        <div className="row mb-4   ">
          <div className="col-6">
            {/* register your input into the hook by invoking the "register" function */}
            <input
              className="form-control"
              placeholder="Item Name"
              {...register("Name", { required: true })}
            />
            {(errors.Name && (
              <span className="text-danger">This field is required</span>
            )) ||
              (!errors.cost && <label className="form-label">Item name</label>)}
          </div>

          <div className="col-3">
            {/* include validation with required or other standard HTML validation rules */}
            <input
              className="form-control"
              placeholder="0.0"
              {...register("price", { required: true, min: 0.01 })}
            />
            {/* errors will return when field validation fails  */}
            {(errors.price && <span className="text-danger">Required</span>) ||
              (!errors.price && <label className="form-label">Price</label>)}
          </div>
          <div className="col-3 justify-content-end">
            <button className="btn btn-primary text-secondary" type="submit">
              Submit{" "}
            </button>
          </div>
        </div>
      </fieldset>
    </form>
  );
};
