import React from "react";
import { Page, ItemList, AddItemForm } from "../../blocks";
import { apiService, alertService } from "../../_services";

export const AdminStandartItemsPage = () => {
  //for test later change hardcoded

  const [standartItems, setStandatItems] = React.useState([]);
  const [itemsLoading, setItemsLoading] = React.useState(true);
  const [successfullySubmitted, setSuccessfullySubmitted] =
    React.useState(false);
  const [successfullyDeleted, setSuccessfullyDeleted] = React.useState(false);

  React.useEffect(() => {
    let cancelled = false;
    const doGetStandartItems = async () => {
      const standartItems = await apiService.getStandartItems();
      if (!cancelled) {
        setStandatItems(standartItems);
        setItemsLoading(false);
      }
    };
    doGetStandartItems();
    return () => {
      cancelled = true;
    };
  }, [successfullySubmitted, successfullyDeleted, itemsLoading]);

  // todo send _submitResult function to form
  const submitResult = (result) => {
    setSuccessfullySubmitted(result ? true : false);
  };

  const alertCloseclick = (action) => {
    if (action === "add") setSuccessfullySubmitted(false);
    if (action === "delete") setSuccessfullyDeleted(false);
  };

  const onDeleteStandartItem = async (id) => {
    const result = await apiService.deleteStandartItem(id);
    if (result) {
      setSuccessfullyDeleted(result ? true : false);
    }
  };

  const onHideItem = async (id, item) => {};

  return (
    <Page>
      {/*<!-- Hero --> */}
      <div className="section-header pb-6 bg-primary overflow-hidden text-center border-bottom border-light">
        <div className="container z-2">
          <div className="row mb-4 justify-content-center">
            <div className="col-12 col-md-8 col-lg-7">
              <h1 className="display-3 mb-4">Standart Items</h1>

              <div className="row justify-content-center">
                <div className="col-lg-10">
                  <div className="mb-6">
                    <ItemList
                      data={standartItems}
                      isSelectable={false}
                      onDelete={onDeleteStandartItem}
                      _deleted={successfullyDeleted}
                      onHide={onHideItem}
                    />

                    {successfullySubmitted && (
                      <div
                        className="alert alert-success alert-dismissible shadow-soft fade show"
                        role="alert"
                      >
                        <span className="alert-inner--icon">
                          <span className="far fa-thumbs-up"></span>
                        </span>
                        <span className="alert-inner--text">
                          <strong>Well done!</strong> Your item was successfully
                          added.
                        </span>
                        <button
                          type="button"
                          className="close"
                          data-dismiss="alert"
                          onClick={() => alertCloseclick("add")}
                        >
                          <span aria-hidden="true">&times;</span>
                        </button>
                      </div>
                    )}

                    {successfullyDeleted && (
                      <div
                        className="alert alert-danger alert-dismissible shadow-soft fade show"
                        role="alert"
                      >
                        <span className="alert-inner--icon">
                          <span className="far fa-thumbs-up"></span>
                        </span>
                        <span className="alert-inner--text">
                          <strong>Well done!</strong> Your item was successfully
                          deleted.
                        </span>
                        <button
                          type="button"
                          className="close"
                          data-dismiss="alert"
                          onClick={() => alertCloseclick("delete")}
                        >
                          <span aria-hidden="true">&times;</span>
                        </button>
                      </div>
                    )}

                    <AddItemForm
                      _submitResult={submitResult}
                      _submited={successfullySubmitted}
                      _addFuncion={apiService.addStandartItem}
                    />
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      {/* <!-- End of Hero -->   */}
    </Page>
  );
};