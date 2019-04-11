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
                
            //sorcery
            // 	var tasks = response["tasks"];
            // 	$("#building_id").empty();
            //   console.log(response);
            // 	$("#building_id").append('<option>Select Task</option>');
            // 	for(var i = 0; i < response.length; i++){
  
            // 		$("#building_id").append('<option value="' + response[i]["id"] + '">' +response[i]["name"] + '</option>');
            // 	}
          }
        });
        console.log(project)
  });

})

