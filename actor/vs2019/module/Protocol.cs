
using System;
using System.Text;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.actor.Proto
{

        public class ApplicationAddRequest
        {
            public ApplicationAddRequest()
            {
                _domain = Any.FromString("");
                _name = Any.FromString("");
                _version = Any.FromString("");
                _program = Any.FromString("");
                _location = Any.FromString("");
                _url = Any.FromString("");
                _upgrade = Any.FromInt32(0);

            }
            [JsonPropertyName("domain")]
            public Any _domain {get;set;}
            [JsonPropertyName("name")]
            public Any _name {get;set;}
            [JsonPropertyName("version")]
            public Any _version {get;set;}
            [JsonPropertyName("program")]
            public Any _program {get;set;}
            [JsonPropertyName("location")]
            public Any _location {get;set;}
            [JsonPropertyName("url")]
            public Any _url {get;set;}
            [JsonPropertyName("upgrade")]
            public Any _upgrade {get;set;}

        }
    
        public class ApplicationUpdateRequest
        {
            public ApplicationUpdateRequest()
            {
                _uuid = Any.FromString("");
                _name = Any.FromString("");
                _version = Any.FromString("");
                _program = Any.FromString("");
                _location = Any.FromString("");
                _url = Any.FromString("");
                _upgrade = Any.FromInt32(0);

            }
            [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}
            [JsonPropertyName("name")]
            public Any _name {get;set;}
            [JsonPropertyName("version")]
            public Any _version {get;set;}
            [JsonPropertyName("program")]
            public Any _program {get;set;}
            [JsonPropertyName("location")]
            public Any _location {get;set;}
            [JsonPropertyName("url")]
            public Any _url {get;set;}
            [JsonPropertyName("upgrade")]
            public Any _upgrade {get;set;}

        }
    
        public class ApplicationRemoveRequest
        {
            public ApplicationRemoveRequest()
            {
                _uuid = Any.FromString("");

            }
            [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}

        }
    
        public class ApplicationListRequest
        {
            public ApplicationListRequest()
            {
                _offset = Any.FromInt64(0);
                _count = Any.FromInt64(0);
                _domain = Any.FromString("");

            }
            [JsonPropertyName("offset")]
            public Any _offset {get;set;}
            [JsonPropertyName("count")]
            public Any _count {get;set;}
            [JsonPropertyName("domain")]
            public Any _domain {get;set;}

        }
    
        public class ApplicationListResponse
        {
            public ApplicationListResponse()
            {
                _status = new Status();
                _total = Any.FromInt64(0);
                _application = new ApplicationEntity[0];

            }
            [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("total")]
            public Any _total {get;set;}
            [JsonPropertyName("application")]
            public ApplicationEntity[] _application {get;set;}

        }
    
        public class DeviceListResponse
        {
            public DeviceListResponse()
            {
                _status = new Status();
                _total = Any.FromInt64(0);
                _device = new DeviceEntity[0];

            }
            [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("total")]
            public Any _total {get;set;}
            [JsonPropertyName("device")]
            public DeviceEntity[] _device {get;set;}

        }
    
        public class DeviceSearchRequest
        {
            public DeviceSearchRequest()
            {
                _offset = Any.FromInt64(0);
                _count = Any.FromInt64(0);
                _serialNumber = Any.FromString("");
                _name = Any.FromString("");
                _operatingSystem = Any.FromString("");
                _systemVersion = Any.FromString("");
                _shape = Any.FromString("");

            }
            [JsonPropertyName("offset")]
            public Any _offset {get;set;}
            [JsonPropertyName("count")]
            public Any _count {get;set;}
            [JsonPropertyName("serialNumber")]
            public Any _serialNumber {get;set;}
            [JsonPropertyName("name")]
            public Any _name {get;set;}
            [JsonPropertyName("operatingSystem")]
            public Any _operatingSystem {get;set;}
            [JsonPropertyName("systemVersion")]
            public Any _systemVersion {get;set;}
            [JsonPropertyName("shape")]
            public Any _shape {get;set;}

        }
    
        public class DeviceSearchResponse
        {
            public DeviceSearchResponse()
            {
                _status = new Status();
                _total = Any.FromInt64(0);
                _device = new DeviceEntity[0];

            }
            [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("total")]
            public Any _total {get;set;}
            [JsonPropertyName("device")]
            public DeviceEntity[] _device {get;set;}

        }
    
        public class DomainCreateRequest
        {
            public DomainCreateRequest()
            {
                _name = Any.FromString("");

            }
            [JsonPropertyName("name")]
            public Any _name {get;set;}

        }
    
        public class DomainUpdateRequest
        {
            public DomainUpdateRequest()
            {
                _uuid = Any.FromString("");
                _name = Any.FromString("");

            }
            [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}
            [JsonPropertyName("name")]
            public Any _name {get;set;}

        }
    
        public class DomainDeleteRequest
        {
            public DomainDeleteRequest()
            {
                _uuid = Any.FromString("");

            }
            [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}

        }
    
        public class DomainListResponse
        {
            public DomainListResponse()
            {
                _status = new Status();
                _total = Any.FromInt64(0);
                _domain = new DomainEntity[0];

            }
            [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("total")]
            public Any _total {get;set;}
            [JsonPropertyName("domain")]
            public DomainEntity[] _domain {get;set;}

        }
    
        public class DomainFindRequest
        {
            public DomainFindRequest()
            {
                _name = Any.FromString("");

            }
            [JsonPropertyName("name")]
            public Any _name {get;set;}

        }
    
        public class DomainFindResponse
        {
            public DomainFindResponse()
            {
                _status = new Status();
                _domain = new DomainEntity();

            }
            [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("domain")]
            public DomainEntity _domain {get;set;}

        }
    
        public class DomainSearchRequest
        {
            public DomainSearchRequest()
            {
                _offset = Any.FromInt64(0);
                _count = Any.FromInt64(0);
                _name = Any.FromString("");

            }
            [JsonPropertyName("offset")]
            public Any _offset {get;set;}
            [JsonPropertyName("count")]
            public Any _count {get;set;}
            [JsonPropertyName("name")]
            public Any _name {get;set;}

        }
    
        public class DomainSearchResponse
        {
            public DomainSearchResponse()
            {
                _status = new Status();
                _total = Any.FromInt64(0);
                _domain = new DomainEntity[0];

            }
            [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("total")]
            public Any _total {get;set;}
            [JsonPropertyName("domain")]
            public DomainEntity[] _domain {get;set;}

        }
    
        public class DomainExecuteRequest
        {
            public DomainExecuteRequest()
            {
                _uuid = Any.FromString("");
                _command = Any.FromString("");
                _device = Any.FromStringAry(new string[0]);
                _parameter = Any.FromString("");

            }
            [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}
            [JsonPropertyName("command")]
            public Any _command {get;set;}
            [JsonPropertyName("device")]
            public Any _device {get;set;}
            [JsonPropertyName("parameter")]
            public Any _parameter {get;set;}

        }
    
        public class GuardFetchRequest
        {
            public GuardFetchRequest()
            {
                _domain = Any.FromString("");
                _offset = Any.FromInt64(0);
                _count = Any.FromInt64(0);
                _filter = new Dictionary<string, string>();

            }
            [JsonPropertyName("domain")]
            public Any _domain {get;set;}
            [JsonPropertyName("offset")]
            public Any _offset {get;set;}
            [JsonPropertyName("count")]
            public Any _count {get;set;}
            [JsonPropertyName("filter")]
            public Dictionary<string, string> _filter {get;set;}

        }
    
        public class GuardFetchResponse
        {
            public GuardFetchResponse()
            {
                _status = new Status();
                _total = Any.FromInt64(0);
                _device = new DeviceEntity[0];
                _access = new Dictionary<string, int>();
                _alias = new Dictionary<string, string>();

            }
            [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("total")]
            public Any _total {get;set;}
            [JsonPropertyName("device")]
            public DeviceEntity[] _device {get;set;}
            [JsonPropertyName("access")]
            public Dictionary<string, int> _access {get;set;}
            [JsonPropertyName("alias")]
            public Dictionary<string, string> _alias {get;set;}

        }
    
        public class GuardEditRequest
        {
            public GuardEditRequest()
            {
                _domain = Any.FromString("");
                _device = Any.FromString("");
                _access = Any.FromInt32(0);
                _alias = Any.FromString("");

            }
            [JsonPropertyName("domain")]
            public Any _domain {get;set;}
            [JsonPropertyName("device")]
            public Any _device {get;set;}
            [JsonPropertyName("access")]
            public Any _access {get;set;}
            [JsonPropertyName("alias")]
            public Any _alias {get;set;}

        }
    
        public class GuardDeleteRequest
        {
            public GuardDeleteRequest()
            {
                _domain = Any.FromString("");
                _device = Any.FromString("");
                _access = Any.FromInt32(0);
                _alias = Any.FromString("");

            }
            [JsonPropertyName("domain")]
            public Any _domain {get;set;}
            [JsonPropertyName("device")]
            public Any _device {get;set;}
            [JsonPropertyName("access")]
            public Any _access {get;set;}
            [JsonPropertyName("alias")]
            public Any _alias {get;set;}

        }
    
        public class Status
        {
            public Status()
            {
                _code = Any.FromInt32(0);
                _message = Any.FromString("");

            }
            [JsonPropertyName("code")]
            public Any _code {get;set;}
            [JsonPropertyName("message")]
            public Any _message {get;set;}

        }
    
        public class BlankRequest
        {
            public BlankRequest()
            {

            }

        }
    
        public class BlankResponse
        {
            public BlankResponse()
            {
                _status = new Status();

            }
            [JsonPropertyName("status")]
            public Status _status {get;set;}

        }
    
        public class ListRequest
        {
            public ListRequest()
            {
                _offset = Any.FromInt64(0);
                _count = Any.FromInt64(0);
                _filter = new Dictionary<string, string>();

            }
            [JsonPropertyName("offset")]
            public Any _offset {get;set;}
            [JsonPropertyName("count")]
            public Any _count {get;set;}
            [JsonPropertyName("filter")]
            public Dictionary<string, string> _filter {get;set;}

        }
    
        public class DomainEntity
        {
            public DomainEntity()
            {
                _uuid = Any.FromString("");
                _name = Any.FromString("");

            }
            [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}
            [JsonPropertyName("name")]
            public Any _name {get;set;}

        }
    
        public class DeviceEntity
        {
            public DeviceEntity()
            {
                _uuid = Any.FromString("");
                _serialNumber = Any.FromString("");
                _name = Any.FromString("");
                _operatingSystem = Any.FromString("");
                _systemVersion = Any.FromString("");
                _shape = Any.FromString("");
                _battery = Any.FromInt32(0);
                _volume = Any.FromInt32(0);
                _brightness = Any.FromInt32(0);
                _storage = Any.FromString("");
                _storageBlocks = Any.FromInt64(0);
                _storageAvailable = Any.FromInt64(0);
                _network = Any.FromString("");
                _networkStrength = Any.FromInt32(0);
                _program = new Dictionary<string, string>();

            }
            [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}
            [JsonPropertyName("serialNumber")]
            public Any _serialNumber {get;set;}
            [JsonPropertyName("name")]
            public Any _name {get;set;}
            [JsonPropertyName("operatingSystem")]
            public Any _operatingSystem {get;set;}
            [JsonPropertyName("systemVersion")]
            public Any _systemVersion {get;set;}
            [JsonPropertyName("shape")]
            public Any _shape {get;set;}
            [JsonPropertyName("battery")]
            public Any _battery {get;set;}
            [JsonPropertyName("volume")]
            public Any _volume {get;set;}
            [JsonPropertyName("brightness")]
            public Any _brightness {get;set;}
            [JsonPropertyName("storage")]
            public Any _storage {get;set;}
            [JsonPropertyName("storageBlocks")]
            public Any _storageBlocks {get;set;}
            [JsonPropertyName("storageAvailable")]
            public Any _storageAvailable {get;set;}
            [JsonPropertyName("network")]
            public Any _network {get;set;}
            [JsonPropertyName("networkStrength")]
            public Any _networkStrength {get;set;}
            [JsonPropertyName("program")]
            public Dictionary<string, string> _program {get;set;}

        }
    
        public class ApplicationEntity
        {
            public ApplicationEntity()
            {
                _uuid = Any.FromString("");
                _name = Any.FromString("");
                _version = Any.FromString("");
                _program = Any.FromString("");
                _location = Any.FromString("");
                _url = Any.FromString("");
                _upgrade = Any.FromInt32(0);

            }
            [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}
            [JsonPropertyName("name")]
            public Any _name {get;set;}
            [JsonPropertyName("version")]
            public Any _version {get;set;}
            [JsonPropertyName("program")]
            public Any _program {get;set;}
            [JsonPropertyName("location")]
            public Any _location {get;set;}
            [JsonPropertyName("url")]
            public Any _url {get;set;}
            [JsonPropertyName("upgrade")]
            public Any _upgrade {get;set;}

        }
    
        public class SyncPushRequest
        {
            public SyncPushRequest()
            {
                _domain = Any.FromString("");
                _device = new DeviceEntity();
                _upProperty = new Dictionary<string, string>();
                _downProperty = Any.FromStringAry(new string[0]);
                _task = Any.FromStringAry(new string[0]);

            }
            [JsonPropertyName("domain")]
            public Any _domain {get;set;}
            [JsonPropertyName("device")]
            public DeviceEntity _device {get;set;}
            [JsonPropertyName("upProperty")]
            public Dictionary<string, string> _upProperty {get;set;}
            [JsonPropertyName("downProperty")]
            public Any _downProperty {get;set;}
            [JsonPropertyName("task")]
            public Any _task {get;set;}

        }
    
        public class SyncPushResponse
        {
            public SyncPushResponse()
            {
                _status = new Status();
                _access = Any.FromInt32(0);
                _alias = Any.FromString("");
                _property = new Dictionary<string, string>();
                _task = new Dictionary<string, string>();

            }
            [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("access")]
            public Any _access {get;set;}
            [JsonPropertyName("alias")]
            public Any _alias {get;set;}
            [JsonPropertyName("property")]
            public Dictionary<string, string> _property {get;set;}
            [JsonPropertyName("task")]
            public Dictionary<string, string> _task {get;set;}

        }
    
        public class SyncPullRequest
        {
            public SyncPullRequest()
            {
                _domain = Any.FromString("");
                _downProperty = Any.FromStringAry(new string[0]);

            }
            [JsonPropertyName("domain")]
            public Any _domain {get;set;}
            [JsonPropertyName("downProperty")]
            public Any _downProperty {get;set;}

        }
    
        public class SyncPullResponse
        {
            public SyncPullResponse()
            {
                _status = new Status();
                _device = new DeviceEntity[0];
                _alias = new Dictionary<string, string>();
                _property = new Dictionary<string, string>();
                _healthy = new Dictionary<string, int>();

            }
            [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("device")]
            public DeviceEntity[] _device {get;set;}
            [JsonPropertyName("alias")]
            public Dictionary<string, string> _alias {get;set;}
            [JsonPropertyName("property")]
            public Dictionary<string, string> _property {get;set;}
            [JsonPropertyName("healthy")]
            public Dictionary<string, int> _healthy {get;set;}

        }
    
        public class SyncUploadRequest
        {
            public SyncUploadRequest()
            {
                _domain = Any.FromString("");
                _device = Any.FromString("");
                _name = Any.FromString("");
                _data = Any.FromString("");

            }
            [JsonPropertyName("domain")]
            public Any _domain {get;set;}
            [JsonPropertyName("device")]
            public Any _device {get;set;}
            [JsonPropertyName("name")]
            public Any _name {get;set;}
            [JsonPropertyName("data")]
            public Any _data {get;set;}

        }
    
}
