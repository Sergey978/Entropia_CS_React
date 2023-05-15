import React from "react";
import { Page, ItemList, AddItemForm } from "../blocks";
import { apiService, alertService } from "../_services";

export const CustomItemsPage = () => {
  //for test later change hardcoded

  const [customItems, setCustomItems] = React.useState([]);
  const [itemsLoading, setItemsLoading] = React.useState(true);
  const [successfullySubmitted, setSuccessfullySubmitted] =
    React.useState(false);
  const [successfullyDeleted, setSuccessfullyDeleted] = React.useState(false);

  React.useEffect(() => {
    let cancelled = false;
    const doGetCustomItems = async () => {
      const customItems = await apiService.getCustomtItems();
      if (!cancelled) {
        setCustomItems(customItems);
        setSuccessfullySubmitted(false);
        setSuccessfullyDeleted(false);
        setItemsLoading(false);
      }
    };
    doGetCustomItems();
    return () => {
      cancelled = true;
    };
  }, [successfullySubmitted, successfullyDeleted, itemsLoading]);

  const onDeleteCustomItem = async (id) => {
    await apiService
      .deleteCustomItem(id)
      .then(() => {
        setSuccessfullyDeleted(true);
        alertService.success("Item was removed!");
      })
      .catch((error) => {
        alertService.error(error);
      });
  };

  const onAddCustomItem = async (params) => {
    apiService
      .addCustomItem(params)
      .then(() => {
        setSuccessfullySubmitted(true);
        alertService.success("Item was added!");
      })
      .catch((error) => {
        alertService.error(error);
      });
  };

  const onHideItem = async (item) => {
    const result = await apiService.hideCustomItem(item.id, {
      ...item,
      selected: !item.selected,
    });

    if (result) {
      setItemsLoading(true);
    }
  };

  return (
    <Page>
      {/*<!-- Hero --> */}
      <div className="section-header pb-6 bg-primary overflow-hidden text-center border-bottom border-light">
        <div className="container z-2">
          <div className="row mb-4 justify-content-center">
            <div className="col-12 col-md-8 col-lg-7">
              <h1 className="display-3 mb-4">Custom Items</h1>

              <div className="row justify-content-center">
                <div className="col-lg-10">
                  <div className="mb-6">
                    <ItemList
                      data={customItems}
                      onDelete={onDeleteCustomItem}
                      _deleted={successfullyDeleted}
                      onHide={onHideItem}
                    />

                    <AddItemForm _addFuncion={onAddCustomItem} />
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
