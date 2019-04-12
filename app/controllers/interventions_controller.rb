class InterventionsController < ApplicationController
    before_action :authenticate_user!
    respond_to :js, :json, :html
    
    # GET /intervention/new
    def new
      
      logger.info("INTERVENTIONS CONTROLLER ")
      
      
    end

    def get_buildings
      logger.info("Get buildings")
    end

    def index
      if request.xhr?
        respond_to do |format|
        format.json do
          cust_id = params[:id]
          @buildings = Building.where(customer_id: cust_id)
          
          logger.info(@buildings)

          response = {add_update: @buildings}
          render json: response
        end
      end
    end
    
    def get_batteries
      if request.xhr?
        respond_to do |format|
        format.json do
          batt_id = params[:id]
          @batteries = Battery.where(building_id: batt_id)
          
          logger.info(@batteries)

          response = {add_update: @batteries}
          render json: response
          end
        end
      end
    end

    def get_columns
        # logger.info("Get Columns -------------")
        if request.xhr?
          respond_to do |format|
          format.json do
            colu_id = params[:id]
            @columns = Column.where(column_id: colu_id)
            
            logger.info(@columns)
  
            response = {add_update: @columns}
            render json: response
          end
        end
      end
    end

    def get_elevators
        if request.xhr?
          respond_to do |format|
          format.json do
            elev_id = params[:id]
            @elevators = Elevator.where(elevator_id: elev_id)
            
            logger.info(@elevators)
  
            response = {add_update: @elevators}
            render json: response
          end
        end
      end
    end


      # end
      # @interventions = Intervention.new
      # @customers = Customer.all
      # @test = Customer.find()
      # @buildings = Customer.find(params[:id]).buildings
      # @batteries = Battery.all
      # @columns = Column.all
      # @elevators = Elevator.all

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
    end
 
