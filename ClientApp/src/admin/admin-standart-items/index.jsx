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
        setSuccessfullySubmitted(false);
        setSuccessfullyDeleted(false);
        setItemsLoading(false);
      }
    };
    doGetStandartItems();
    return () => {
      cancelled = true;
    };
  }, [successfullyDeleted, successfullySubmitted, itemsLoading]);

  const onAddstandartItem = async (params) => {
    apiService
      .addStandartItem(params)
      .then(() => {
        setSuccessfullySubmitted(true);
        alertService.success("Item was added!");
      })
      .catch((error) => {
        alertService.error(error);
      });
  };

  const onDeleteStandartItem = async (id) => {
    apiService
      .deleteStandartItem(id)
      .then(() => {
        setSuccessfullyDeleted(true);
        alertService.success("Item was removed!");
      })
      .catch((error) => {
        alertService.error(error);
      });
  };

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
                    />

                    <AddItemForm _addFuncion={onAddstandartItem} />
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
