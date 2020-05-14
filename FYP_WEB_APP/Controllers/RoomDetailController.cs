﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using FYP_APP.Controllers;
using FYP_WEB_APP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FYP_WEB_APP.Controllers
{
    public class RoomDetailController : Controller
    {
        //[Route("RoomDetail/RoomDetail/{roomID}")]
        public IActionResult RoomDetail(String roomID)
        {
            ViewData["roomID"] = roomID;
            SensorsController sensorsController = new SensorsController();
            List<SensorsListModel> sensorsList = sensorsController.getSensorsListByRoomid(roomID);
            
            Debug.WriteLine("sensor list = "+sensorsList);
            
            return View();
        }

        [HttpPost]
        public IActionResult AddDragButton(IFormCollection post) {
            Debug.WriteLine("sensorID = " + post["sensor_type"] + post["sensorNo"]);
            ViewData["roomID"] = post["roomID"];
            Debug.WriteLine("AddDragButton room id = " + ViewData["roomID"]);
            return Redirect("RoomDetail?roomID="+ ViewData["roomID"]+"#floorPlan");
        }

    }
}
