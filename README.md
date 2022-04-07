# waxel-world
Repository for the P2E game Waxel World
## deploy smart contract
1. create waxel accout at https://waxsweden.org/create-testnet-account/
	-- waxelowner12 as a deployer
	{"msg": "succeeded", "keys": {"active_key": {"public": "EOS54qYPpsgojFHqhYxT6vfdoGWA3bFG1BtPgMHyhfnnqipZYxaQj", "private": "5HxgZQvaJmkpTNN6SZi1waowGagCcvdnUeDvEfJekoUYryhwFKR"}, "owner_key": {"public": "EOS8QBnVgvVvwqg24sTrQAcnkVFgUfdj8S5DKW3Ey3JK9FnWiVgR2", "private": "5KUHu1Cn4tpbT9m3Nb55uM2w7tctH7G4ty1qWQG6nfvPZZ8V7PU"}}, "account": "waxelowner12"}
	-- waxeltest123 as a test
	{"msg": "succeeded", "keys": {"active_key": {"public": "EOS6uBBvLbd6yFeare7qmBD4ecXXXmmh5Qz96ZCTksJ9Xq11Gwb4C", "private": "5JgBPZynEx6rpuCVkcpzZJouGAVGE637JkTXwb8iKqsH3Macm4q"}, "owner_key": {"public": "EOS6pnNwufiPCgnGX2BahBEYLjpLteQdWF3P2aWZwyby5QiGVXAgj", "private": "5JiwFs3chUCRnaHhUpRkbtXJXVQJzWm7eNca5h7FomfDVF63ACf"}}, "account": "waxeltest123"}
	-- waxeltest134 as a test
	{"msg": "succeeded", "keys": {"active_key": {"public": "EOS8dQXZtAYyqYdh2gxYR4jada9ApEfk7xerzWU1Y6kHYhwLxW2yR", "private": "5KFdo6GcpB4m9xvNBPr9Ykkoi6qSsCSPWuacYD4QayQfYC4jKiu"}, "owner_key": {"public": "EOS6gpGBwXoKWnhwUsNSS1NejRMH1cnkWGKWx2yPVfa1vDzbBccCt", "private": "5JnDBux78W9MXMPvfSLqqmSVKwop5u55bKSUudQXnXknQNJBui7"}}, "account": "waxeltest134"}
2. create and getting wallet password
cleos wallet create -n waxelwallet --to-console &&
cleos wallet import -n waxelwallet --private-key 5HxgZQvaJmkpTNN6SZi1waowGagCcvdnUeDvEfJekoUYryhwFKR &&
cleos wallet import -n waxelwallet --private-key 5KUHu1Cn4tpbT9m3Nb55uM2w7tctH7G4ty1qWQG6nfvPZZ8V7PU
3. deploying contract to the deployer account
cd waxel
cleos wallet open -n waxelwallet &&
cleos wallet unlock -n waxelwallet --password PW5K8iKjxvzCByAqDa6pjn6sJSGT5Xg7B7ae75z8vB7nu8fH7aUvk
cleos -u https://testnet.waxsweden.org set contract waxelowner12 $(pwd) waxel.wasm waxel.abi
