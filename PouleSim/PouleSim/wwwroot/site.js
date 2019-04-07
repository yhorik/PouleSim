$(document).ready(function() {
  
});


function generateTeams() {
  $.ajax({
    type: "GET",
    accepts: "application/json",
    url: "api/sim/teams/generate",
    contentType: "application/json",
    error: function(jqXHR, textStatus, errorThrown) {
      alert("Something went wrong!");
    },
    success: function(result) {
      //getData();
      //$("#teams").val(result);
	  const tBody = $("#teams");

      $(tBody).empty();
	  
	  const header = $("<tr><td>Name</td><td>Offense</td><td>Defense</td></tr>");
	  header.appendTo(tBody);
	  $.each(result, function(key, item) {
        const tr = $("<tr></tr>")
          .append($("<td></td>").text(item.name))
          .append($("<td></td>").text(item.offense+"/15"))
          .append($("<td></td>").text(item.defense+"/15"));

        tr.appendTo(tBody);
      });
    }
  });
}

function runPoule(){

	$.ajax({
    type: "GET",
    accepts: "application/json",
    url: "api/sim/poule	",
    contentType: "application/json",
    error: function(jqXHR, textStatus, errorThrown) {
      alert("Something went wrong!");
    },
    success: function(result) {
      //getData();
      //$("#teams").val(result);
	  const tBody = $("#matches");

      $(tBody).empty();
	  
	  const header = $("<tr><td>Match</td><td>Result</td></tr>");
	  header.appendTo(tBody);
	  $.each(result.matches, function(key, item) {
        const tr = $("<tr></tr>")
          .append($("<td></td>").text("Team"+item.teamOne+" - "+"Team"+item.teamTwo))
          .append($("<td></td>").text(item.scoreOne+" - "+item.scoreTwo));

        tr.appendTo(tBody);
      });
	  
	  
	  const tBody2 = $("#results");

      $(tBody2).empty();
	  
	  const header2 = $("<tr><td>Team</td><td>Points</td><td>Goal Differential</td><td>Goals Scored</td></tr>");
	  header2.appendTo(tBody2);
	  var id = 0;
	  $.each(result.standings, function(key, item) {
		id++;
        const tr = $("<tr id='position"+id+"'></tr>")
          .append($("<td></td>").text("Team"+item.team))
          .append($("<td></td>").text(item.points))
          .append($("<td></td>").text(item.goalDifferential))
          .append($("<td></td>").text(item.goalsScored));

        tr.appendTo(tBody2);
      });
    }
  });
}