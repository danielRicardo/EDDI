using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Eddi;
using EddiEvents;
using Utilities;
using EddiStatusMonitor;

namespace EddiSerialResponder
{
    /// <summary>
    /// A responder that responds to events by sending data over a serial port
    /// Designed to be used as a framework for building physical cockpit panels that display the game status
    /// </summary>
    public class SerialResponder : EDDIResponder
    {
        public static readonly string LogFile = Constants.DATA_DIR + @"\serialresponder.out";

        protected static List<Event> eventQueue = new List<Event>();
        private static readonly object queueLock = new object();

        private SerialPort serialPort;

        public SerialResponder(string portName)
        {
            this.serialPort = new SerialPort(portName, 9600);
        }
        public string ResponderName()
        {
            return "Serial Responder";
        }

        public string LocalizedResponderName()
        {
            return Properties.SerialResponder.name;
        }

        public string ResponderDescription()
        {
            return Properties.SerialResponder.desc;
        }

        public bool Start()
        {
            EDDI.Instance.State["serialresponder_quiet"] = false;
            return true;
        }

        public void Stop()
        {
            EDDI.Instance.State["serialreponder_quiet"] = true;
        }

        public void Reload()
        {
            throw new NotImplementedException();
        }

        public UserControl ConfigurationTabItem()
        {
            throw new NotImplementedException();
        }

        public void Handle(Event @event)
        {
            if (@event.fromLoad)
            {
                return;
            }

            switch (@event)
            {
                case CockpitBreachedEvent cockpitBreachedEvent:
                    break;
                case ControllingFighterEvent controllingFighterEvent:
                    break;
                case ControllingShipEvent controllingShipEvent:
                    break;
                case DockingCancelledEvent dockingCancelledEvent:
                    break;
                case DockingDeniedEvent dockingDeniedEvent:
                    break;
                case DockingGrantedEvent dockingGrantedEvent:
                    break;
                case DockingRequestedEvent dockingRequestedEvent:
                    break;
                case DockingTimedOutEvent dockingTimedOutEvent:
                    break;
                case EnteredNormalSpaceEvent enteredNormalSpaceEvent:
                    break;
                case EnteredSupercruiseEvent enteredSupercruiseEvent:
                    break;
                case FighterDockedEvent fighterDockedEvent:
                    break;
                case FighterLaunchedEvent fighterLaunchedEvent:
                    break;
                case FSDEngagedEvent fsdEngagedEvent:
                    break;
                case ShipFsdEvent shipFsdEvent:
                    this.serialPort.WriteLine($"FSD_STATUS;{shipFsdEvent.fsd_status}");
                    break;
                case ShipInterdictedEvent shipInterdictedEvent:
                    break;
                case ShipInterdictionEvent shipInterdictionEvent:
                    break;
                case FSDTargetEvent fsdTargetEvent:
                    this.serialPort.WriteLine($"FSD_TARGET_EVENT;{fsdTargetEvent.system};{fsdTargetEvent.remainingjumpsinroute}");
                    break;
                case GlideEvent glideEvent:
                    break;
                case HeatDamageEvent heatDamageEvent:
                    break;
                case HeatWarningEvent heatWarningEvent:
                    break;
                case HullDamagedEvent hullDamagedEvent:
                    break;
                case JetConeBoostEvent jetConeBoostEvent:
                    break;
                case JumpedEvent jumpedEvent:
                    break;
                case JumpingEvent jumpingEvent:
                    break;
                case LiftoffEvent liftoffEvent:
                    break;
                case NPCAttackCommencedEvent npcAttackCommencedEvent:
                    break;
                case NPCCargoScanCommencedEvent npcCargoScanCommencedEvent:
                    break;
                case NPCInterdictionCommencedEvent npcInterdictionCommencedEvent:
                    break;
                case RingHotspotsEvent ringHotspotsEvent:
                    break;
                case RingMappedEvent ringMappedEvent:
                    break;
                case RouteDetailsEvent routeDetailsEvent:
                    break;
                case ShieldsDownEvent shieldsDownEvent:
                    break;
                case ShieldsUpEvent shieldsUpEvent:
                    break;
                case ShipCargoScoopEvent shipCargoScoopEvent:
                    break;
                case ShipLandingGearEvent shipLandingGearEvent:
                    this.serialPort.WriteLine($"LANDING_GEAR;{shipLandingGearEvent.deployed}");
                    break;
                case ShipLightsEvent shipLightsEvent:
                    break;
                case ShipLowFuelEvent shipLowFuelEvent:
                    break;
                case ShipTargetedEvent shipTargetedEvent:
                    break;
                case SilentRunningEvent silentRunningEvent:
                    break;
                case SRVDockedEvent srvDockedEvent:
                    break;
                case SRVLaunchedEvent srvLaunchedEvent:
                    break;
                case StationNoFireZoneEnteredEvent stationNoFireZoneEnteredEvent:
                    break;
                case StationNoFireZoneExitedEvent stationNoFireZoneExitedEvent:
                    break;
                case UnderAttackEvent underAttackEvent:
                    break;
                case UndockedEvent undockedEvent:
                    break;
                case BodyMappedEvent bodyMappedEvent:
                    break;
                case BodyScannedEvent bodyScannedEvent:
                    break;
                case CargoDepotEvent cargoDepotEvent:
                    break;
                case CargoWingUpdateEvent cargoWingUpdateEvent:
                    break;
                case ClearedSaveEvent clearedSaveEvent:
                    break;
                case CombatPromotionEvent combatPromotionEvent:
                    break;
                case CommanderContinuedEvent commanderContinuedEvent:
                    break;
                case CommanderLoadingEvent commanderLoadingEvent:
                    break;
                case CommanderProgressEvent commanderProgressEvent:
                    break;
                case CommanderRatingsEvent commanderRatingsEvent:
                    break;
                case CommanderReputationEvent commanderReputationEvent:
                    break;
                case CommanderStartedEvent commanderStartedEvent:
                    break;
                case CrewAssignedEvent crewAssignedEvent:
                    break;
                case CrewFiredEvent crewFiredEvent:
                    break;
                case CrewHiredEvent crewHiredEvent:
                    break;
                case CrewJoinedEvent crewJoinedEvent:
                    break;
                case CrewLeftEvent crewLeftEvent:
                    break;
                case CrewMemberJoinedEvent crewMemberJoinedEvent:
                    break;
                case CrewMemberLaunchedEvent crewMemberLaunchedEvent:
                    break;
                case CrewMemberLeftEvent crewMemberLeftEvent:
                    break;
                case CrewMemberRemovedEvent crewMemberRemovedEvent:
                    break;
                case CrewMemberRoleChangedEvent crewMemberRoleChangedEvent:
                    break;
                case CrewPaidWageEvent crewPaidWageEvent:
                    break;
                case CrewPromotionEvent crewPromotionEvent:
                    break;
                case CrewRoleChangedEvent crewRoleChangedEvent:
                    break;
                case DatalinkMessageEvent datalinkMessageEvent:
                    break;
                case DataScannedEvent dataScannedEvent:
                    break;
                case DataVoucherAwardedEvent dataVoucherAwardedEvent:
                    break;
                case DataVoucherRedeemedEvent dataVoucherRedeemedEvent:
                    break;
                case DiedEvent diedEvent:
                    break;
                case DiscoveryScanEvent discoveryScanEvent:
                    break;
                case DockedEvent dockedEvent:
                    break;
                case EmpirePromotionEvent empirePromotionEvent:
                    break;
                case EngineerContributedEvent engineerContributedEvent:
                    break;
                case EngineerProgressedEvent engineerProgressedEvent:
                    break;
                case EnteredCQCEvent enteredCqcEvent:
                    break;
                case EnteredSignalSourceEvent enteredSignalSourceEvent:
                    break;
                case ExplorationDataPurchasedEvent explorationDataPurchasedEvent:
                    break;
                case ExplorationDataSoldEvent explorationDataSoldEvent:
                    break;
                case ExplorationPromotionEvent explorationPromotionEvent:
                    break;
                case FederationPromotionEvent federationPromotionEvent:
                    break;
                case FighterRebuiltEvent fighterRebuiltEvent:
                    break;
                case FileHeaderEvent fileHeaderEvent:
                    break;
                case FriendsEvent friendsEvent:
                    break;
                case JetConeDamageEvent jetConeDamageEvent:
                    break;
                case KilledEvent killedEvent:
                    break;
                case LocationEvent locationEvent:
                    break;
                case MarketEvent marketEvent:
                    break;
                case MarketInformationUpdatedEvent marketInformationUpdatedEvent:
                    break;
                case MaterialCollectedEvent materialCollectedEvent:
                    break;
                case MaterialDiscardedEvent materialDiscardedEvent:
                    break;
                case MaterialDiscoveredEvent materialDiscoveredEvent:
                    break;
                case MaterialDonatedEvent materialDonatedEvent:
                    break;
                case MaterialInventoryEvent materialInventoryEvent:
                    break;
                case MaterialTradedEvent materialTradedEvent:
                    break;
                case MessageReceivedEvent messageReceivedEvent:
                    break;
                case MessageSentEvent messageSentEvent:
                    break;
                case ModificationCraftedEvent modificationCraftedEvent:
                    break;
                case MusicEvent musicEvent:
                    break;
                case NavBeaconScanEvent navBeaconScanEvent:
                    break;
                case NearSurfaceEvent nearSurfaceEvent:
                    break;
                case OutfittingEvent outfittingEvent:
                    break;
                case PowerDefectedEvent powerDefectedEvent:
                    break;
                case PowerJoinedEvent powerJoinedEvent:
                    break;
                case PowerLeftEvent powerLeftEvent:
                    break;
                case PowerplayEvent powerplayEvent:
                    break;
                case PowerPreparationVoteCast powerPreparationVoteCast:
                    break;
                case PowerSalaryClaimedEvent powerSalaryClaimedEvent:
                    break;
                case PowerVoucherReceivedEvent powerVoucherReceivedEvent:
                    break;
                case ScreenshotEvent screenshotEvent:
                    break;
                case SearchAndRescueEvent searchAndRescueEvent:
                    break;
                case SelfDestructEvent selfDestructEvent:
                    break;
                case SettlementApproachedEvent settlementApproachedEvent:
                    break;
                case ShipyardEvent shipyardEvent:
                    break;
                case ShutdownEvent shutdownEvent:
                    break;
                case SignalDetectedEvent signalDetectedEvent:
                    break;
                case SquadronRankEvent squadronRankEvent:
                    break;
                case SquadronStartupEvent squadronStartupEvent:
                    break;
                case SquadronStatusEvent squadronStatusEvent:
                    break;
                case SRVTurretDeployableEvent srvTurretDeployableEvent:
                    break;
                case SRVTurretEvent srvTurretEvent:
                    break;
                case StarScannedEvent starScannedEvent:
                    break;
                case StatisticsEvent statisticsEvent:
                    break;
                case SurfaceSignalsEvent surfaceSignalsEvent:
                    break;
                case SynthesisedEvent synthesisedEvent:
                    break;
                case SystemScanComplete systemScanComplete:
                    break;
                case TechnologyBrokerEvent technologyBrokerEvent:
                    break;
                case TouchdownEvent touchdownEvent:
                    break;
                case TradeDataPurchasedEvent tradeDataPurchasedEvent:
                    break;
                case TradePromotionEvent tradePromotionEvent:
                    break;
                case TradeVoucherRedeemedEvent tradeVoucherRedeemedEvent:
                    break;
                case UnhandledEvent unhandledEvent:
                    break;
                case VAInitializedEvent vaInitializedEvent:
                    break;
                case VehicleDestroyedEvent vehicleDestroyedEvent:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(@event));
            }
        }
    }
}
