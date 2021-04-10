import React from "react";

// components

import TeamCardTable from "components/Cards/TeamCardTable.js";

export default function TeamList() {
  return (
    <>
      <div className="flex flex-wrap mt-4">
        <div className="w-full mb-12 px-4">
          <TeamCardTable />
        </div>
        {/* <div className="w-full mb-12 px-4">
          <CardTable color="dark" />
        </div> */}
      </div>
    </>
  );
}
