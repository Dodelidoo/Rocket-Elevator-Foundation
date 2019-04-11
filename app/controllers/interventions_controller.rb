class InterventionsController < ApplicationController
    before_action :authenticate_user!
    respond_to :js, :json, :html
    
    # GET /intervention/new
    def new
      
      logger.info("INTERVENTIONS CONTROLLER ")
      
      
    end

    def index
      if request.xhr?
        respond_to do |format|
        format.json do
          cust_id = params[:id]
          
          logger.info(cust_id)
          response = {add_update: "building_id"}
          render json: response
        end
      end
      end
      @interventions = Intervention.new
      @customers = Customer.all
      # @test = Customer.find()
      # @buildings = Customer.find(params[:id]).buildings
      # @batteries = Battery.all
      # @columns = Column.all
      # @elevators = Elevator.all
    end

    def buildingValue
      

    if params[:id].present?
        @buildings = Customer.find(params[:id]).buildings
    else
        @buildings = Customer.all
    end
    if request.xhr?
        respond_to do |format|
            format.json {
                render json: {buildings: @buildings}
            }
        end
      end
    end
    def batteryValue
      

      if params[:id].present?
          @batteries = Building.find(params[:id]).batteries
      else
          @batteries = Building.all
      end
      if request.xhr?
          respond_to do |format|
              format.json {
                  render json: {batteries: @batteries}
              }
          end
        end
      end
      def columnValue
      

        if params[:id].present?
            @columns = Battery.find(params[:id]).columns
        else
            @columns = Battery.all
        end
        if request.xhr?
            respond_to do |format|
                format.json {
                    render json: {columns: @columns}
                }
            end
          end
        end
        def elevatorValue
      

          if params[:id].present?
              @elevators = Column.find(params[:id]).elevators
          else
              @elevators = Column.all
          end
          if request.xhr?
              respond_to do |format|
                  format.json {
                      render json: {elevators: @elevators}
                  }
              end
            end
          end
  end