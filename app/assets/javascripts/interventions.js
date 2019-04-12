//$("#hour_task_id").prop("disabled", true); // second dropdown is disable while first dropdown is empty
$(document).ready(function(){


    $("#customer_id").change(function(){
        var project = $(this).val();
        if(project == ''){
        $("#customer_id").prop("disabled", true);
         }else{
            $("#building_id").prop("disabled", false);
            console.log();
        }
        $.ajax({
          url: "/interventions",
          method: "GET",  
          dataType: "json",
          data: {id: project},
          error: function (xhr, status, error) {
            	console.error('AJAX Error: ' + status + error);
          },
          success: function (response) {
                console.log(response);
                
            
            	var buildings = response["add_update"];
             	$("#building_id").empty();
               console.log(buildings);
             	$("#building_id").append('<option>Select Building</option>');
             	for(var i = 0; i < buildings.length; i++){
  
                 $("#building_id").append('<option value="' + buildings[i]["id"] + '">' +buildings[i]["address_id"] + '</option>');
                 
             	}
          }
        });
        console.log(project)
  });

    $("#building_id").change(function(){
      var project = $(this).val();
      if(project == ''){
      $("#building_id").prop("disabled", true);
      }else{
          $("#battery_id").prop("disabled", false);
          console.log();
      }
      $.ajax({
        url: "/interventions/get_batteries",
        method: "GET",  
        dataType: "json",
        data: {id: project},
        error: function (xhr, status, error) {
            console.error('AJAX Error: ' + status + error);
        },
        success: function (response) {
              console.log(response);
              
          
            var batteries = response["add_update"];
            $("#battery_id").empty();
            console.log(batteries);
            $("#battery_id").append('<option>Select Battery</option>');
            for(var i = 0; i < batteries.length; i++){

              $("#battery_id").append('<option value="' + batteries[i]["id"] + '">' +batteries[i]["id"] + '</option>');
              
            }
        }
      });
      console.log(project)
  });

    $("#battery_id").change(function(){
      var project = $(this).val();
      if(project == ''){
      $("#battery_id").prop("disabled", true);
      }else{
          $("#column_id").prop("disabled", false);
          console.log();
      }
      $.ajax({
        url: "/interventions/get_columns",
        method: "GET",  
        dataType: "json",
        data: {id: project},
        error: function (xhr, status, error) {
            console.error('AJAX Error: ' + status + error);
        },
        success: function (response) {
              console.log(response);
              
          
            var columns = response["add_update"];
            $("#column_id").empty();
            console.log(columns);
            $("#column_id").append('<option>Select Column</option>');
            for(var i = 0; i < columns.length; i++){

              $("#column_id").append('<option value="' + columns[i]["id"] + '">' +columns[i]["column_id"] + '</option>');
              
            }
        }
      });
      console.log(project)
    });

    $("#column_id").change(function(){
      var project = $(this).val();
      if(project == ''){
      $("#column_id").prop("disabled", true);
       }else{
          $("#elevator_id").prop("disabled", false);
          console.log();
      }
      $.ajax({
        url: "/interventions/get_elevators",
        method: "GET",  
        dataType: "json",
        data: {id: project},
        error: function (xhr, status, error) {
            console.error('AJAX Error: ' + status + error);
        },
        success: function (response) {
              console.log(response);
              
          
            var elevators = response["add_update"];
             $("#elevator_id").empty();
             console.log(elevators);
             $("#elevator_id").append('<option>Select Elevator</option>');
             for(var i = 0; i < columns.length; i++){
    
               $("#elevator_id").append('<option value="' + elevators[i]["id"] + '">' +elevators[i]["serial_number"] + '</option>');
               
             }
        }
      });
      console.log(project)
    });
})

